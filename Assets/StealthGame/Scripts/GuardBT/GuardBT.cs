using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;
using Tree = BehaviourTree.Tree;

public class GuardBT : Tree
{
    [SerializeField] private GameObject _guardGameObject;
    [SerializeField] private float _guardMoveSpeed = 5;
    [SerializeField] private Transform _pathHolder;

    protected override Node SetupTree()
    {
        ConditionIsPlayerSpotted conditionIsPlayerSpotted = new ConditionIsPlayerSpotted(_guardGameObject);
        ActionGoTowardPlayer goTowardPlayer = new ActionGoTowardPlayer(6f);
        ActionGuardPatrol guardPatrol = new ActionGuardPatrol( _guardGameObject, _pathHolder, _guardMoveSpeed);
        Sequence sequence = new Sequence(new List<Node> { conditionIsPlayerSpotted, goTowardPlayer }, identifier);

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

        // Gizmos.color = Color.red;
        // Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}
