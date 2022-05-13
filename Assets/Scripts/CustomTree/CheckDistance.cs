using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class CheckDistance : Condition
{
    public Transform pos;
    public Transform target;

    public CheckDistance(Transform position, Transform targ) : base("Distance")
    {
        pos = position;
        target = targ;
    }


    public override void OnUpdate(float elapsedTime)
    {
        if (Vector3.Distance(target.position, pos.position) < 10)
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