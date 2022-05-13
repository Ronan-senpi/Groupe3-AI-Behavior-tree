using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class CheckDistance : Condition
{
    private Transform position;
    private Transform target;
    private float distance;

    public CheckDistance(Transform position, Transform target, float dist) : base("Distance")
    {
        this.position = position;
        this.target = target;
        distance = dist;
    }


    public override void OnUpdate(float elapsedTime)
    {
        if (Vector3.Distance(target.position, position.position) < 10)
        {
            state = NodeState.Success;
        }
        else
        {
            state = NodeState.Failed;
        }
    }


    public override void OnEnd()
    {
    }
}