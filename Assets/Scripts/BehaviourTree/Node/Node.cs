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

namespace BehaviourTree.Nodes
{
    public abstract class Node
    {
        protected NodeState state = NodeState.NotExecuted;
        protected List<Node> children;
        public string nodeName;

        public Node(string name, List<Node> childrenNodes)
        {
            nodeName = name; 
            children = childrenNodes;
        }

        public virtual void OnStart()
        {
            state = NodeState.Running;
        }

        public virtual void OnUpdate(float elapsedTime){}

        public virtual NodeState Evaluate()
        {
            return state;
        }

        public abstract void OnEnd();

        public virtual void Reset()
        {
            state = NodeState.NotExecuted;
        }
    }
}