using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class AttackSpell : Action
{
    private BossController boss;
    private float animationDuration;
    private float currentTimer;
    public AttackSpell(BossController bc) : base("AttackSpell")
    {
        boss = bc;
    }

    public override void OnStart()
    {
        base.OnStart();
        boss.HitboxSpell.gameObject.SetActive(true);
        boss.Animator.SetTrigger(AnimationNames.Spell);
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