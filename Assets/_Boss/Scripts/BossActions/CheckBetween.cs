using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class CheckBetween : Condition
{
    private Transform bossPosition;
    private Transform target;
    private Vector2 range;
    public CheckBetween(Transform bc, Transform target, Vector2 range) : base("CheckBetween")
    {
        bossPosition = bc;
        this.target = target;
        this.range = range;
    }

    public override void OnUpdate(float elapsedTime)
    {
        float distanceTarget = Vector3.Distance(target.position, bossPosition.position);

        if ((range.x <= distanceTarget && distanceTarget <= range.y))
        {
            state = NodeState.Success;
        }
        else
        {
            state = NodeState.Failed;
        }
    }
}