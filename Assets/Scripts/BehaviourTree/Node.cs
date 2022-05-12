using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum NodeState
{
    NotExecuted,
    Running,
    Success,
    Failed
}

namespace BehaviourTree
{
    public abstract class Node
    {
        protected NodeState state = NodeState.NotExecuted;
        protected List<Node> children;

        public Node(List<Node> childrenNodes)
        {
            children = childrenNodes;
        }

        public virtual void OnStart()
        {
            state = NodeState.Running;
        }

        public virtual void OnUpdate(){}

        public virtual NodeState Evaluate()
        {
            Debug.Log("Evaluate");
            return state;
        }

        public abstract void OnEnd();
    }
}