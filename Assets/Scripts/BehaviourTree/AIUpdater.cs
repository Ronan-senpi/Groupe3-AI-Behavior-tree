using System.Collections;
using BehaviourTree.Nodes;
using UnityEngine;

public class AIUpdater : MonoBehaviour
{
    #region Singleton Instance

    private static AIUpdater instance;

    public static AIUpdater Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AIUpdater>();
                if (instance == null)
                {
                    GameObject go = new GameObject("AIUpdater");
                    instance = go.AddComponent<AIUpdater>();
                }
            }

            return instance;
        }
    }

    #endregion


    public const float AI_UPDATE_FREQUENCY = 0.05f;
    private bool updatingAI = true;
    private Node currentNode;
    private NodeState previousState;

    private void Awake()
    {
        StartCoroutine(UpdateAI());
    }


    /// <summary>
    /// Update AI Behaviour. Called every AI_UPDATE_FREQUENCY seconds
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpdateAI()
    {
        var wait = new WaitForSeconds(AI_UPDATE_FREQUENCY);
        while (updatingAI)
        {
            if (currentNode != null)
            {
                NodeState currentState = currentNode.Evaluate();
                if (currentState == NodeState.NotExecuted)
                {
                    currentNode.OnStart();
                    currentNode.OnUpdate(AI_UPDATE_FREQUENCY);
                }
                else if (currentState == NodeState.Running)
                {
                    currentNode.OnUpdate(AI_UPDATE_FREQUENCY);
                }
                else if (previousState != currentState &&
                         (currentState == NodeState.Success || currentState == NodeState.Failed))
                {
                    currentNode.OnEnd();
                }

                previousState = currentState;
            }

            yield return wait;
        }
    }

    public void SetCurrentNode(Node newNode)
    {
        currentNode = newNode;
    }
}