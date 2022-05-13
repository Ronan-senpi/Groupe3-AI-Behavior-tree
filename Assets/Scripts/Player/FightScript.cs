using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FightScript : HealthController
{
    [SerializeField] private HitboxController hitbox;

    [SerializeField] private float damage;

    [SerializeField] private LayerMask targetMask;
    // Start is called before the first frame update
    void Start()
    {
        hitbox.Duration = null;
        hitbox.Damage = damage;
        hitbox.TargetMask = targetMask;
    }

    public void EnableHitbox()
    {
        hitbox.Col.enabled = true;
    }

    public void disableHitbox()
    {
        hitbox.Col.enabled = false;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger(AnimationNames.Slash);
        }
    }
    
}