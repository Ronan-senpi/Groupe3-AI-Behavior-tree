using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    public class Sequence : Node
    {
        public Sequence(List<Node> childrenNodes) : base("Sequence", childrenNodes)
        {
        }

        public override NodeState Evaluate()
        {
            //Debug.Log("Evaluate de sequence");
            foreach (Node node in children)
            {
                NodeState childState = node.Evaluate();
                
                //Debug.Log("Inside sequence : " + node.nodeName + " node's state is " + childState);
                
                if (childState == NodeState.NotExecuted)
                {
                    AIUpdater.Instance.SetCurrentNode(node);
                    state = NodeState.Running;
                    return state;
                }

                if (childState != NodeState.Success)
                {
                    
                    state = childState;
                    return state;
                }
            }

            //Debug.Log("SEQUENCE SUCCESS");
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
        public override void OnEnd()
        {
            throw new System.NotImplementedException();
        }
    }
}