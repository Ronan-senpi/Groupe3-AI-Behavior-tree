using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class PowerUp : Action
{
    private BossController boss;
    private float animationDuration;
    private float currentTimer;
    public PowerUp(BossController bc) : base("PowerUp")
    {
        boss = bc;
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("Call PuwerUPer");
        boss.Animator.SetTrigger(AnimationNames.Power);
        boss.Effect.SetActive(true);
        animationDuration = boss.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        currentTimer = 0;
    }

    public override void OnUpdate(float elapsedTime)
    {
        Debug.Log("");
        currentTimer += elapsedTime;
        if (currentTimer > animationDuration)
        {
            boss.IsPowerUp = true;
            state = NodeState.Success;
        }
    }

    public override void OnEnd()
    {
        currentTimer = 0;
    }
}