using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class Invert : Node
    {
        public Invert(Node child) : base(new List<Node>() { child })
        {
        }

        public override void OnStart()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            NodeState revertState = children[0].Evaluate();
            if (revertState == NodeState.Failed)
            {
                state = NodeState.Success;
            }

            if (revertState == NodeState.Success)
            {
                state = NodeState.Failed;
            }

            state = NodeState.Running;
        }


        public override void OnEnd()
        {
            throw new System.NotImplementedException();
        }
    }
}