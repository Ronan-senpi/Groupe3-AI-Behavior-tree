using System.Collections.Generic;

namespace BehaviourTree
{
    
    /// <summary>
    /// A node that repeats its child as long as isRepeating is true
    /// </summary>
    public class Repeat : Node
    {
        public bool isRepeating = true;
        public Repeat(Node child) : base(new List<Node>{child})
        {
        }

        public override void OnStart(){}

        public override NodeState OnUpdate()
        {
            if (isRepeating)
            {
                NodeState childval = children[0].OnUpdate();
                if (childval == NodeState.Failed) return NodeState.Failed;
                else return NodeState.Running;
            }
            return NodeState.Success;
            
        }

        public override void OnEnd()
        {
            isRepeating = true;
        }
    }
}