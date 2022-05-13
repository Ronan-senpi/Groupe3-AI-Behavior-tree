using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class AttackSword : Action
{
    private BossController boss;
    private float animationDuration;
    private float currentTimer;
    public AttackSword(BossController bc) : base("AttackSword")
    {
        boss = bc;
    }

    public override void OnStart()
    {
        base.OnStart();
        boss.HitboxSword.gameObject.SetActive(true);
        boss.Animator.SetTrigger(AnimationNames.Slash);
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