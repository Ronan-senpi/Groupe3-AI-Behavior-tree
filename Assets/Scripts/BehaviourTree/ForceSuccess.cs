using System.Collections.Generic;

namespace BehaviourTree
{
    public class ForceSuccess : Node
    {
        
        /// <summary>
        /// Returns always Success when OnUpdate is called
        /// </summary>
        public ForceSuccess(List<Node> childrenNodes) : base(childrenNodes)
        {
        }

        public override void OnStart()
        {
            
        }

        public override NodeState OnUpdate()
        {
            return NodeState.Success;
        }

        public override void OnEnd()
        {
            
        }
    }
}