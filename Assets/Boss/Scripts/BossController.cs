using System;
using UnityEngine;
using UnityExtendedEditor.Attributes;
using System.Collections;
using UnityEngine.Serialization;

static class BossAnimationNames
{
    public static string Spell { get; } = "Spell";
    public static string Death { get; } = "Death";
    public static string Idle { get; } = "Sword And Shield Idle";
    public static string Impact { get; } = "Impact";
    public static string Kick { get; } = "Kick";
    public static string Power { get; } = "PowerUp";
    public static string Run { get; } = "Run";
    public static string Slash { get; } = "Slash";
}

public class BossController : LineOfSight
{
    [SerializeField] private Transform target;
    [SerializeField] private Animator animator;
    [SerializeField] [Range(25, 100)] private float healthPoints = 50f;
    public float HealthPoints => healthPoints;
    private float currentHealthPoints = 50f;
    [SerializeField] [Range(0, 3)] private float recoveryTime = 1.5f;
    private bool canTakeDamage = true;


    [Header("Movement")] [SerializeField] private float speed = 10f;

    [SerializeField] private float selfSpace = 3f;

    [SerializeField] private LayerMask toHitLayer;

    #region Kick

    [Header("Kick")] [SerializeField] [MinMaxSlider(0.1f, 20)]
    private Vector2 kickRange = new Vector2(0f, 5f);

    [FormerlySerializedAs("distanceKickProjection")] [SerializeField] private float forceKickProjection = 5f;
    [SerializeField] private float kickDamages = 2.5f;
    [SerializeField] private HitboxKickController hitboxKick;

    [SerializeField] private Color kickColor = Color.blue;

    public Vector2 KickRange => kickRange;
    public float ForceKickProjection => forceKickProjection * powerRate;
    public float KickDamages => kickDamages * powerRate;
    public Color KickColor => kickColor;

    #endregion Kick

    #region Sword

    [Header("Sword")] [SerializeField] [MinMaxSlider(1, 20)]
    private Vector2 swordRange = new Vector2(0f, 5f);

    [SerializeField] private float sowrdDamages = 5f;
    [SerializeField] private HitboxController hitboxSword;
    [SerializeField] private Color swordColor = Color.cyan;
    public Vector2 SwordRange => swordRange;
    public float SwordDamages => sowrdDamages * powerRate;
    public Color SwordColor => swordColor;

    #endregion Sword

    #region spell

    
    [Header("Spell")] [SerializeField] [MinMaxSlider(1, 20)]
    private Vector2 spellRange = new Vector2(10f, 20f);

    [SerializeField] private float spellDamages = 5f;
    [SerializeField] private HitboxController hitboxSpell;
    [SerializeField] [Range(2f, 10f)] private float spellCooldown = 7f;
    [SerializeField] [Range(2f, 10f)] private float spellDuration = 7f;
    [SerializeField] private Color spellColor = Color.magenta;
    private bool canCastSpell = true;

    public Vector2 SpellRange => spellRange;
    public float SpellDamages => spellDamages * powerRate;
    public float SpellCooldown => spellCooldown;
    public Color SpellColor => spellColor;

    private Vector3 spellPositionOrigin;

    #endregion spell

    #region PowerUp

    [Header("PowerUp")] [SerializeField] [Range(1, 2)]
    private float powerUpRate = 1.33f;

    #endregion PowerUp

    private float powerRate = 1f;

    private void Start()
    {
        currentHealthPoints = healthPoints;
        // spell hitbox stetup
        hitboxSpell.Damage = SpellDamages;
        hitboxSpell.Duration = spellDuration;
        hitboxSpell.TargetMask = toHitLayer;
        spellPositionOrigin = hitboxSpell.gameObject.transform.position;
        // kick hitbox setup;
        hitboxKick.Damage = KickDamages;
        hitboxKick.TargetMask = toHitLayer;
        hitboxKick.ForceKickProjection = ForceKickProjection;
        //sword hitbox setup
        hitboxSword.Damage = SwordDamages;
        hitboxSword.TargetMask = toHitLayer;
    }

    private void Update()
    {
        if (currentHealthPoints <= 0)
        {
            this.Death();
            return;
        }

        AttackCastSpell();
    }

    void Death()
    {
        animator.SetTrigger(BossAnimationNames.Death);
    }

    void Impact(int damages)
    {
        float distanceTarget = Vector3.Distance(target.position, transform.position);
        if (canTakeDamage && (kickRange.x <= distanceTarget && distanceTarget <= kickRange.y))
        {
            canTakeDamage = false;
            animator.SetTrigger(BossAnimationNames.Impact);
            currentHealthPoints -= damages;
            StartCoroutine(ResetDamageStatus());
        }
    }

    IEnumerator ResetDamageStatus()
    {
        yield return new WaitForSeconds(recoveryTime);
        canTakeDamage = true;
    }

    //Fonction pour le BT

    void PowerUp()
    {
    }

    void ReachPlayer()
    {
        Vector3 targetPos = new Vector3(target.position.x,
            transform.position.y,
            target.position.z);
        transform.LookAt(targetPos);
        if (Vector3.Distance(transform.position, targetPos) > selfSpace)
        {
            transform.position += transform.forward * (Time.deltaTime * speed);
            animator.SetBool(BossAnimationNames.Run, true);
        }
        else
        {
            animator.SetBool(BossAnimationNames.Run, false);
        }
    }

    void AttackCastSpell()
    {
        float distanceTarget = Vector3.Distance(target.position, transform.position);
        if (canCastSpell && (spellRange.x <= distanceTarget && distanceTarget <= spellRange.y))
        {
            hitboxSpell.gameObject.SetActive(true);
            canCastSpell = false;
            animator.SetTrigger(BossAnimationNames.Spell);
            hitboxSpell.gameObject.transform.position =
                new Vector3(target.position.x, 0, target.position.z);
            StartCoroutine(ResetSpellStatus());
        }
    }

    IEnumerator ResetSpellStatus()
    {
        yield return new WaitForSeconds(spellCooldown);
        canCastSpell = true;
        hitboxSpell.gameObject.transform.position = spellPositionOrigin;
    }

    void AttackKick()
    {
        float distanceTarget = Vector3.Distance(target.position, transform.position);
        if ((kickRange.x <= distanceTarget && distanceTarget <= kickRange.y))
        {
            hitboxKick.gameObject.SetActive(true);
            animator.SetTrigger(BossAnimationNames.Kick);
        }
    }

    void AttackSword()
    {
        float distanceTarget = Vector3.Distance(target.position, transform.position);
        if ((swordRange.x <= distanceTarget && distanceTarget <= swordRange.y))
        {
            hitboxSword.gameObject.SetActive(true);
            animator.SetTrigger(BossAnimationNames.Slash);
        }
    }
}