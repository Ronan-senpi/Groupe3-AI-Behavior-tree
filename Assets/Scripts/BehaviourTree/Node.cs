using System.Collections.Generic;
using UnityEditor;

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
        protected NodeState state;
        protected List<Node> children = new List<Node>();

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
            return state;
        }

        public abstract void OnEnd();
    }
}