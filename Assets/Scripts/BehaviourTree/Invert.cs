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

        public override NodeState OnUpdate()
        {
            NodeState revertState = children[0].OnUpdate();
            if (revertState == NodeState.Failed)
            {
                state = NodeState.Success;
                return state;
            }

            if (revertState == NodeState.Success)
            {
                state = NodeState.Failed;
                return state;
            }

            state = NodeState.Running;
            return state;
        }

        public override void OnEnd()
        {
            throw new System.NotImplementedException();
        }
    }
}