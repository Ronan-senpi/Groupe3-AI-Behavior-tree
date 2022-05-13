using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    /// <summary>
    /// Sequence of behaviour tree.
    /// Iterates on nodes in children until every node is in Success state.
    /// Stop execution if a node return Failed.
    /// </summary>
    public class Sequence : Control
    {
        public Sequence(List<Node> childrenNodes, string treeId) : base("Sequence", treeId, childrenNodes)
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

                if (childState != NodeState.Success)
                {
                    state = childState;
                    return state;
                }
            }

            state = NodeState.Success;
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