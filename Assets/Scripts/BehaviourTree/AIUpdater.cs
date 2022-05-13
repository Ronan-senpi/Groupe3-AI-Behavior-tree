using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BehaviourTree.Nodes;
using UnityEngine;

/// <summary>
/// A class to manage every AI in the scene
/// </summary>
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

    [Tooltip("Time in seconds between each update of the AI")] [SerializeField]
    private float AI_UPDATE_FREQUENCY = 0.05f;

    private bool updatingAI = true;
    private Dictionary<string, Node> AINodes = new Dictionary<string, Node>();
    private Dictionary<string, Node> bufferAINodes = new Dictionary<string, Node>();
    private NodeState previousState;

    private void Start()
    {
        StartCoroutine(UpdateAI());
    }


    private IEnumerator UpdateAI()
    {
        var wait = new WaitForSeconds(AI_UPDATE_FREQUENCY);
        Node currentNode;

        while (updatingAI)
        {
            bufferAINodes = new Dictionary<string, Node>(AINodes); //createBuffer(AINodes);
            Debug.Log("bufferAINodes.Count " + bufferAINodes.Count + " AINodes.Count " + AINodes.Count);
            foreach (var currentAI in bufferAINodes)
            {
                currentNode = currentAI.Value;

                if (currentNode == null)
                {
                    continue;
                }

                NodeState currentState = currentNode.Evaluate();
                if (currentState == NodeState.NotExecuted)
                {
                    Debug.Log("NotExecuted");
                    currentNode.OnStart();
                    currentNode.OnUpdate(AI_UPDATE_FREQUENCY);
                }
                else if (currentState == NodeState.Running)
                {
                    Debug.Log("Running");
                    currentNode.OnUpdate(AI_UPDATE_FREQUENCY);
                }
                else if (previousState != currentState &&
                         (currentState == NodeState.Success || currentState == NodeState.Failed))
                {
                    Debug.Log("The end");
                    currentNode.OnEnd();
                }
                else
                {
                    Debug.Log(currentState);
                }

                previousState = currentState;
            }

            yield return wait;
        }
    }

    private Dictionary<string, Node> createBuffer(Dictionary<string, Node> aiNodes)
    {
        Dictionary<string, Node> buffer = new Dictionary<string, Node>();
        for (int i = 0; i < aiNodes.Count; i++)
        {
            string key = aiNodes.ElementAt(i).Key;
            Node val = aiNodes.ElementAt(i).Value;
            buffer[aiNodes.ElementAt(i).Key] = aiNodes.ElementAt(i).Value;
        }

        /*foreach(var pair in aiNodes)
        {
            buffer[pair.Key] = pair.Value;
        }}*/

        return buffer;
    }

    /// <summary>
    /// Update the behaviour of the AI with a new Node
    /// </summary>
    /// <param name="id">The identifier of the AI to update</param>
    /// <param name="newNode">This node will replace the current behaviour of the AI</param>
    public void SetCurrentNode(string id, Node newNode)
    {
        AINodes[id] = newNode;
    }
}