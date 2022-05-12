using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;
using Tree = BehaviourTree.Tree;

public class EnemyTree : Tree
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private float jumpingForce = 10f;
    protected override Node SetupTree()
    {
        MoveForward moveForward = new MoveForward(enemyController,1, 2);
        JumpAction jumpAction = new JumpAction(enemyController,jumpingForce);
        Wait waitAfterJump = new Wait(0.5f);
        Sequence sequence = new Sequence(new List<Node> { moveForward, jumpAction, waitAfterJump });
        return sequence;
    }
}
