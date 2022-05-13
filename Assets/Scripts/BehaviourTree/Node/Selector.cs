using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviourTree.Nodes
{
    public class Selector : Control
    {
        public Selector(List<Node> childrenNodes, string treeId) : base("Selector", treeId, childrenNodes)
        {
        }

        public override void OnStart()
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

        public override void OnEnd()
        {
        }
    }
}