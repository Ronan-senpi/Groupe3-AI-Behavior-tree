using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviourTree.Nodes
{
    public class Selector : Node
    {
        public Selector(List<Node> childrenNodes) : base("Selector", childrenNodes)
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
                    AIUpdater.Instance.SetCurrentNode(node);
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

        public override void OnEnd()
        {
        }
    }
}