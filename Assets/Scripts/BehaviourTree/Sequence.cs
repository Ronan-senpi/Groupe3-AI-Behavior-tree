using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class Sequence : Node
    {
        public Sequence(List<Node> childrenNodes) : base(childrenNodes)
        {
        }

        public override void OnStart()
        {
            throw new System.NotImplementedException();
        }

        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                NodeState childState = node.Evaluate();
                if (childState != NodeState.Success)
                {
                    state = childState;
                    return state;
                }
            }

            state = NodeState.Success;
            return state;
        }

        public override void OnEnd()
        {
            throw new System.NotImplementedException();
        }
    }
}