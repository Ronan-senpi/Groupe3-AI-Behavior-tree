using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviourTree.Nodes
{
    /// <summary>
    /// Selector of behaviour tree.
    /// Iterates on nodes in children to find the next action to execute.
    /// Choose the first node that is in NotExecuted state and can be executed.
    /// If the node is in Failed State, the selector moves to the next child.
    /// The last node will be the default action to execute
    /// </summary>
    public class Selector : Control
    {
        public Selector(List<Node> childrenNodes, string treeId) : base("Selector", treeId, childrenNodes)
        {
        }

        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                NodeState childState = node.Evaluate();
                if (childState == NodeState.NotExecuted)
                {
                    AIUpdater.Instance.SetCurrentNode(treeId, node);
                    state = NodeState.Running;
                    return state;
                }

                if (childState != NodeState.Failed)
                {
                    state = childState;
                    return state;
                }
            }

            state = NodeState.Failed;
            return state;
        }

        public override void Reset()
        {
            foreach (Node node in children)
            {
                node.Reset();
            }
        }
    }
}