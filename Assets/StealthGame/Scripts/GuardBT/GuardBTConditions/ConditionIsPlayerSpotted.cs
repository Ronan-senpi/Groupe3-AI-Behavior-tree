using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class ConditionIsPlayerSpotted : Condition
{
    private GameObject _guardGameObject;
    public ConditionIsPlayerSpotted(GameObject guardGameObject) : base("Is Player Spotted")
    {
        _guardGameObject = guardGameObject;
    }


    public override void OnUpdate(float elapsedTime)
    {
        Debug.Log("Check");
        if (_guardGameObject.GetComponent<GuardController>().isPlayerSpotted())
        {
            state = NodeState.Success;
        }
        else
        {
            state = NodeState.Failed;
        }
        Debug.Log(state);
    }


    public override void OnEnd()
    {
    }
}
