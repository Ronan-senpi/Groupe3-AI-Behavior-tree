using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class Attack : Action
{
    private BossController boss;
    private HitboxController hitbox;
    private string attackName;
    private float animationDuration;
    private float currentTimer;
    public Attack(BossController bc, HitboxController hc, string attackName) : base("AttackKick")
    {
        boss = bc;
        hitbox = hc;
        this.attackName = attackName;
    }

    public override void OnStart()
    {
        base.OnStart();
        hitbox.gameObject.SetActive(true);
        boss.Animator.SetTrigger(attackName);
        animationDuration = boss.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        currentTimer = 0;
    }

    public override void OnUpdate(float elapsedTime)
    {
        currentTimer += elapsedTime;
        if (currentTimer > animationDuration)
        {
            state = NodeState.Success;
        }
    }

    public override void OnEnd()
    {
        
        currentTimer = 0;
    }
}