using System.Collections.Generic;

namespace BehaviourTree.Nodes
{
    public class ForceFailure : Node

    {
        /// <summary>
        /// Returns always Failed when OnUpdate is called
        /// </summary>
        public ForceFailure(List<Node> childrenNodes) : base("ForceFailure", childrenNodes)
        {
        }

        public override NodeState Evaluate()
        {
            return NodeState.Failed;
        }
    }
}