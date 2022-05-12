using System.Collections.Generic;

namespace BehaviourTree.Nodes
{
    public class ForceSuccess : Node
    {
        /// <summary>
        /// Returns always Success when OnUpdate is called
        /// </summary>
        public ForceSuccess(List<Node> childrenNodes) : base("ForceSuccess", childrenNodes)
        {
        }

        public override void OnStart()
        {
        }

        public override NodeState Evaluate()
        {
            return NodeState.Success;
        }

        public override void OnEnd()
        {
        }
    }
}