using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using Unity.VisualScripting;
using UnityEngine;

public class ReachPlayer : Action
{
    private BossController boss;
    private Transform target;

    public ReachPlayer(BossController bc, Transform target) : base("ReachPlayer")
    {
        boss = bc;
        this.target = target;
    }

    public override void OnStart()
    {
        base.OnStart();
        boss.CanRun = true;

        boss.Animator.SetBool(AnimationNames.Run, true);
    }


    public override void OnUpdate(float elapsedTime)
    {
        state = NodeState.Success;
    }

    public override void OnEnd()
    {
        boss.Animator.SetBool(AnimationNames.Run, false);
    }
}