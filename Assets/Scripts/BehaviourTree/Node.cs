using System.Collections.Generic;
using UnityEditor;

public enum NodeState
{
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

        public abstract NodeState OnUpdate();

        public abstract void OnEnd();
    }
}