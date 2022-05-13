using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class ConditionIsOnCooldown : Condition
{
    private GameObject _guardGameObject;
    public ConditionIsOnCooldown(GameObject guardGameObject) : base("Is On Cooldown")
    {
        _guardGameObject = guardGameObject;
    }


    public override void OnUpdate(float elapsedTime)
    {
        if (_guardGameObject.GetComponent<GuardController>().isOnCooldown())
        {
            state = NodeState.Failed;
        }
        else
        {
            state = NodeState.Success;
        }
    }


    public override void OnEnd()
    {
    }
}
