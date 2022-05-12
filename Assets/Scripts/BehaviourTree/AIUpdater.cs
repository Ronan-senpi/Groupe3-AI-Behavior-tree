using System;
using System.Collections;
using System.Collections.Generic;
using BehaviourTree;
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

    private const float AI_UPDATE_FREQUENCY = 0.04f;
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
                if (currentState == NodeState.NotExecuted)
                {
                    currentNode.OnStart();
                    currentNode.OnUpdate();
                }
                else if (currentState == NodeState.Running)
                {
                    currentNode.OnUpdate();
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