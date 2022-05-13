using BehaviourTree.Nodes;
using UnityEngine;

public class ActionGoTowardPlayer : Action
{
    public ActionGoTowardPlayer(float movingSpeed) : base("Go Toward Player")
    {
    }
    public override void OnStart()
    {
        Debug.Log("Start Go Toward Player");
    }
    public override void OnUpdate(float elapsedTime)
    {
        Debug.Log("Update Go Toward Player");
    }

    public override void Reset()
    {
    }

    public override void OnEnd()
    {
    }
}
