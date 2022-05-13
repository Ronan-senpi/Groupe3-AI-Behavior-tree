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
    /// <summary>
    /// Base abstract  class for every node of the Behaviour Tree. 
    /// </summary>
    public abstract class Node
    {
        protected NodeState state = NodeState.NotExecuted;
        protected List<Node> children;
        private string nodeName;

        public Node(string name, List<Node> childrenNodes)
        {
            nodeName = name;
            children = childrenNodes;
        }

        /// <summary>
        /// Function called at the beginning of the execution of the node
        /// </summary>
        public virtual void OnStart()
        {
            state = NodeState.Running;
        }

        /// <summary>
        /// Function called at the beginning of the execution of the node
        /// </summary>
        /// <param name="elapsedTime"> Time passed between two execution of UpdateAI in AIUpdater</param>
        public virtual void OnUpdate(float elapsedTime)
        {
        }

        /// <summary>
        /// Check the current state of the node, eventually by checking state of children
        /// </summary>
        /// <returns>NodeState of the node</returns>
        public virtual NodeState Evaluate()
        {
            return state;
        }

        
        /// <summary>
        /// Function called at the end of the execution of the node (Failed or Success)
        /// </summary>
        public virtual void OnEnd()
        {
        }

        public virtual void Reset()
        {
            state = NodeState.NotExecuted;
        }

        public string GetName()
        {
            return nodeName;
        }
    }
}