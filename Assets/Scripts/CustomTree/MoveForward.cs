
using BehaviourTree.Nodes;
using UnityEngine;

public class MoveForward : Action
{
    
    private EnemyController enemyController;
    private float moveDuration = 1f;
    private float movingSpeed = 5f;
    private float startMovingTime;
    private bool isMoving;
    public MoveForward(EnemyController enemyController, float moveDuration, float movingSpeed) : base("Move Forward")
    {
        this.enemyController = enemyController;
        this.moveDuration = moveDuration;
        this.movingSpeed = movingSpeed;
    }

    public override void OnStart()
    {
        base.OnStart();
        startMovingTime = Time.time;
        isMoving = true;
    }
    public override void OnUpdate(float elapsedTime)
    {
        enemyController.Move(enemyController.transform.forward, movingSpeed*elapsedTime);
        
        float movingElapsed = Time.time - startMovingTime;
        if (isMoving && movingElapsed >= moveDuration)
        {
            state = NodeState.Success;
        }
    }

    public override void Reset()
    {
        base.Reset();
        isMoving = false;
    }

    public override void OnEnd()
    {
    }
}