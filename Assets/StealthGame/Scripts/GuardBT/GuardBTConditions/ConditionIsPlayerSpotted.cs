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
        if (_guardGameObject.GetComponent<GuardController>().isPlayerSpotted())
        {
            Debug.Log("Check Success");
            state = NodeState.Success;
        }
        else
        {
            Debug.Log("Check Failed");
            state = NodeState.Failed;
        }
    }


    public override void OnEnd()
    {
    }
}
