using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;
using Tree = BehaviourTree.Tree;

public class GuardBT : Tree
{
    [SerializeField] private GameObject _guardGameObject;
    [SerializeField] private float _guardMoveSpeedWalk = 5;
    [SerializeField] private float _guardMoveSpeedRun = 6;
    [SerializeField] private Transform _pathHolder;

    protected override Node SetupTree()
    {
        ConditionIsOnCooldown conditionIsOnCooldown = new ConditionIsOnCooldown(_guardGameObject);
        ConditionIsPlayerSpotted conditionIsPlayerSpotted = new ConditionIsPlayerSpotted(_guardGameObject);
        ActionGoTowardPlayer goTowardPlayer = new ActionGoTowardPlayer(_guardGameObject, _guardMoveSpeedRun);
        ActionGuardPatrol guardPatrol = new ActionGuardPatrol( _guardGameObject, _pathHolder, _guardMoveSpeedWalk);
        Sequence sequence = new Sequence(new List<Node> { conditionIsOnCooldown, conditionIsPlayerSpotted, goTowardPlayer }, identifier);

        Selector selec = new Selector(new List<Node>{sequence, guardPatrol}, identifier);

        return selec;
    }

    void OnDrawGizmos() {
        Vector3 startPosition = _pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;
        foreach(Transform waypoint in _pathHolder){
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.color = Color.black;
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);
    }
}
