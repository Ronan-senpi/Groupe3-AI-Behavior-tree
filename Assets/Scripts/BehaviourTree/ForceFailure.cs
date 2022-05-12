using System.Collections.Generic;

namespace BehaviourTree
{
    public class ForceFailure : Node

    {
        /// <summary>
        /// Returns always Failed when OnUpdate is called
        /// </summary>
        public ForceFailure(List<Node> childrenNodes) : base(childrenNodes)
        {
        }

        public override void OnStart()
        {
        }

        public override NodeState Evaluate()
        {
            return NodeState.Failed;
        }

        public override void OnEnd()
        {
        }
    }
}