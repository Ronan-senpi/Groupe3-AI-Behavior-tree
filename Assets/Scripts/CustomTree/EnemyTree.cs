using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;
using Tree = BehaviourTree.Tree;

public class EnemyTree : Tree
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private float jumpingForce = 10f;
    public Transform target;

    protected override Node SetupTree()
    {
        MoveForward moveForward = new MoveForward(enemyController, 1, 2);
        JumpAction jump = new JumpAction(enemyController, jumpingForce);
        CheckDistance dist = new CheckDistance(this.transform, target, 5);
        Sequence sequence = new Sequence(new List<Node> { dist, jump }, identifier);

        Selector selec = new Selector(new List<Node> { sequence, moveForward }, identifier);

        return selec;
    }
}