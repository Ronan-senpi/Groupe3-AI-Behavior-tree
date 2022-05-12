using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviourTree
{
    public class Selector : Node
    {
        public Selector(List<Node> childrenNodes) : base(childrenNodes)
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
                if (state != NodeState.Failed)
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