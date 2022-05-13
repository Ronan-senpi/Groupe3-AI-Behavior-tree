using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class ActionGuardPatrol : Action
{
    private GameObject _guardGameObject;
    private float _guardMoveSpeed;
    private Transform _pathHolder;
    private Vector3[] _waypoints;
    private int _targetWaypointIndex;
    [SerializeField] private float _turnSpeed = 120;

    [SerializeField] private const float _waitTimeSeconds = 0.2f;
    private float _waitCounter;
    private bool _waiting;

    public ActionGuardPatrol(GameObject guardGameObject, Transform pathHolder, float guardMoveSpeed) : base("Guard Patrol")
    {
        _guardGameObject = guardGameObject;
        _pathHolder = pathHolder;
        _guardMoveSpeed = guardMoveSpeed;

        _waypoints = new Vector3[pathHolder.childCount];
        for(int i = 0 ; i < _waypoints.Length; i++){
            _waypoints[i] = pathHolder.GetChild(i).position;
            _waypoints[i] = new Vector3(_waypoints[i].x, _guardGameObject.transform.position.y, _waypoints[i].z);
        }
        _guardGameObject.transform.position = _waypoints[0];
        _guardGameObject.transform.LookAt(_waypoints[1]);
        
        _waiting = true;
        _waitCounter = 0f;
    }
    public override void OnStart()
    {
        base.OnStart();
    }
    public override void OnUpdate(float elapsedTime)
    {
        if(_guardGameObject.GetComponent<GuardController>().isPlayerSpotted())
            state = NodeState.Success;
            
        _targetWaypointIndex = _guardGameObject.GetComponent<GuardController>().getTargetWaypointIndex();

        Vector3 targetWaypoint = _waypoints[_targetWaypointIndex];
        Vector3 dirToLookTarget = (targetWaypoint - _guardGameObject.transform.position).normalized;
        float targetAngle = 90-Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;
        float differenceAngle = Mathf.Abs(Mathf.DeltaAngle(_guardGameObject.transform.eulerAngles.y, targetAngle));
       
        if (_waiting)
        {
            _waitCounter += elapsedTime;
            if (_waitCounter >= _waitTimeSeconds)
            {
                _waiting = false;
            }
            return;
        }

        if(_guardGameObject.transform.position != targetWaypoint){
            _guardGameObject.transform.position = Vector3.MoveTowards(_guardGameObject.transform.position, targetWaypoint, _guardMoveSpeed * elapsedTime);
        }
        
        if(differenceAngle>0.05f) {
            float angle = Mathf.MoveTowardsAngle(_guardGameObject.transform.eulerAngles.y, targetAngle, _turnSpeed * elapsedTime);
            _guardGameObject.transform.eulerAngles = Vector3.up * angle;
        }

        if(_guardGameObject.transform.position != targetWaypoint || differenceAngle>0.05f) {
            return;
        }

        _guardGameObject.GetComponent<GuardController>().setTargetWaypointIndex((_targetWaypointIndex+1) % _waypoints.Length);
        
        state = NodeState.Success;
    }

}
