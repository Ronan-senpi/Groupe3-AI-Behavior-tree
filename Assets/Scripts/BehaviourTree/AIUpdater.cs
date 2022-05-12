using System.Collections;
using BehaviourTree.Nodes;
using UnityEngine;

public class AIUpdater : MonoBehaviour
{
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

    public const float AI_UPDATE_FREQUENCY = 0.05f;
    private bool updatingAI = true;
    private Node currentNode;

    private void Awake()
    {
        StartCoroutine(UpdateAI());
    }

    private IEnumerator UpdateAI()
    {
        Debug.Log("UpdateAI first call");
        var wait = new WaitForSeconds(AI_UPDATE_FREQUENCY);
        while (updatingAI)
        {
            if (currentNode != null)
            {
                NodeState currentState = currentNode.Evaluate();
                //Debug.Log(currentNode.nodeName + " " + currentState);
                if (currentState == NodeState.NotExecuted)
                {
                    currentNode.OnStart();
                    currentNode.OnUpdate(AI_UPDATE_FREQUENCY);
                }
                else if (currentState == NodeState.Running)
                {
                    currentNode.OnUpdate(AI_UPDATE_FREQUENCY);
                }
                else if (currentState == NodeState.Success || currentState == NodeState.Failed)
                {
                    currentNode.OnEnd();
                }
            }
            

            yield return wait;
        }
    }

    public void SetCurrentNode(Node newNode)
    {
        currentNode = newNode;
    }
}