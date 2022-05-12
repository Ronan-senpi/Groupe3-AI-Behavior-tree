using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;

public class JumpAction: Action
{
    private float jumpForce = 10f;
    private EnemyController enemyController;
    
    public JumpAction(EnemyController enemyController, float force) : base("JumpAction")
    {
        jumpForce = force;
        this.enemyController = enemyController;
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("Jumping baby !");
        enemyController.rb.AddForce(enemyController.transform.up*jumpForce,ForceMode.Impulse);
        enemyController.isGrounded = false;
    }

    public override void OnUpdate(float elapsedTime)
    {
        if (enemyController.isGrounded)
        {
            Debug.Log("J'ai touché le sol putaing");
            state = NodeState.Success;
        }
    }

    public override void OnEnd()
    {
    }
}