using System.Collections.Generic;
using UnityEditor;

public enum NodeState
{
    NotExectued,
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

        public abstract void OnStart();

        public virtual void OnUpdate(){}

        public virtual NodeState Evaluate()
        {
            return state;
        }

        public abstract void OnEnd();
    }
}