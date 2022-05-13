using BehaviourTree.Nodes;
using UnityEngine;

public class ActionGoTowardPlayer : Action
{
    public ActionGoTowardPlayer(float movingSpeed) : base("Go Toward Player")
    {
    }
    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("Start Go Toward Player");
    }
    public override void OnUpdate(float elapsedTime)
    {
        Debug.Log("Update Go Toward Player");
        state = NodeState.Success;
    }

    public override void Reset()
    {
        base.Reset();
    }

    public override void OnEnd()
    {
    }
}
