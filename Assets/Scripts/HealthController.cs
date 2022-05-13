using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HealthController : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] [Range(0, 1000)] protected float healthPoints = 500f;
    public float HealthPoints => healthPoints;
    [SerializeField] [Range(0, 1000)] protected float currentHealthPoints;
    public float CurrentHealthPoints => currentHealthPoints;
    [SerializeField] [Range(0, 3)] protected float recoveryTime = 1.5f;
    public bool CanTakeDamage { get; set; } = true;
    public Rigidbody Rb { get; protected set; }

    // Start is called before the first frame update
    void Awake()
    {
        currentHealthPoints = healthPoints;
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public virtual void Death()
    {
        animator.SetTrigger(AnimationNames.Death);
    }

    public virtual void Impact(float damages)
    {
        CanTakeDamage = false;
        animator.SetTrigger(AnimationNames.Impact);
        currentHealthPoints -= damages;
        StartCoroutine(ResetDamageStatus());
        if (currentHealthPoints <= 0)
        {
            this.Death();
            return;
        }
    }

    IEnumerator ResetDamageStatus()
    {
        yield return new WaitForSeconds(recoveryTime);
        CanTakeDamage = true;
    }
}