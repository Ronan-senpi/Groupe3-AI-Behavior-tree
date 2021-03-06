using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    /// <summary>
    /// This node can only have one node child.
    /// Returns Failed when child state is Success, or Success when child state is Failed
    /// </summary>
    public class Invert : Node
    {
        public Invert(Node child) : base("Invert", new List<Node>() { child })
        {
        }

        public override void OnUpdate(float elapsedTime)
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
    }
}