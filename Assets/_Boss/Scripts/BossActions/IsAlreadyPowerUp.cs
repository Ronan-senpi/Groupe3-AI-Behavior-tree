using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class IsAlreadyPowerUp : Condition
{
    private BossController boss;

    public IsAlreadyPowerUp(BossController bc) : base("PoweredUp")
    {
        boss = bc;
    }

    public override void OnUpdate(float elapsedTime)
    {
        if (boss.IsPowerUp)
        {
            state = NodeState.Failed;
        }
        else
        {
            state = NodeState.Success;
        }
    }
}