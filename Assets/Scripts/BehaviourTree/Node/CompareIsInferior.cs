using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class CompareIsInferior : Condition
{
    private HealthController hc;
    private float comparor;

    public CompareIsInferior(HealthController hc, float comparor) : base("Comparison")
    {
        this.hc = hc;
        this.comparor = comparor;
    }

    public override void OnUpdate(float elapsedTime)
    {
        if (hc.CurrentHealthPoints <= comparor)
        {
            
            state = NodeState.Success;
        }
        else
        {
            state = NodeState.Failed;
        }
    }
}