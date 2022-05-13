using BehaviourTree.Nodes;
using UnityEngine;

public class ActionGoTowardPlayer : Action
{
    private GameObject _guardGameObject;
    private float _guardMoveSpeed;
    [SerializeField] private const float _waitTimeSeconds = 1f;
    private float _waitCounter;
    public ActionGoTowardPlayer(GameObject guardGameObject, float guardMoveSpeed) : base("Go Toward Player")
    {
        _guardGameObject = guardGameObject;
        _guardMoveSpeed = guardMoveSpeed;
        _waitCounter = 0f;
    }
    public override void OnStart()
    {
        base.OnStart();
    }
    public override void OnUpdate(float elapsedTime)
    {
        //_guardGameObject.GetComponent<GuardController>().ChasePlayer();
        _guardGameObject.transform.position = Vector3.MoveTowards(_guardGameObject.transform.position, _guardGameObject.GetComponent<GuardController>().getplayerTransform().position, _guardMoveSpeed * elapsedTime);
        _guardGameObject.transform.LookAt(_guardGameObject.GetComponent<GuardController>().getplayerTransform().position);
        _waitCounter += elapsedTime;
        if (_waitCounter >= _waitTimeSeconds){
            _waitCounter = 0;
            _guardGameObject.GetComponent<GuardController>().StartCooldown();
            state = NodeState.Success;
        }
    }

}
