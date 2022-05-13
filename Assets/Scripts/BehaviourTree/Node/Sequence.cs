using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BehaviourTree.Nodes
{
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