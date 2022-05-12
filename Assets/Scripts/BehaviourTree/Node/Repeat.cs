using System.Collections.Generic;

namespace BehaviourTree.Nodes
{
    
    /// <summary>
    /// A node that repeats its child as long as isRepeating is true
    /// </summary>
    public class Repeat : Node
    {
        public bool isRepeating = true;
        public Repeat(Node child) : base("Repeat", new List<Node>{child})
        {
        }

        public override void OnStart(){}

        public override void OnUpdate(float elapsedTime)
        {
            // if (isRepeating)
            // {
            //     NodeState childval = children[0].Evaluate();
            //     if (childval == NodeState.Failed) return NodeState.Failed;
            //     else return NodeState.Running;
            // }
            // return NodeState.Success;
            
        }

        public override void OnEnd()
        {
            isRepeating = true;
        }
    }
}