using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace BehaviourTree.Nodes
{
    /// <summary>
    /// A node that picks randomly one of its children and executes it
    /// </summary>
    public class RandomPicker : Node
    {
        public RandomPicker(List<Node> childrenNodes) : base("RandomPicker", childrenNodes)
        {
        }

        public override void OnStart()
        {
        }

        public override void OnUpdate(float elapsedTime)
        {
            int randPos = Random.Range(0, children.Count);
            Node node = children[randPos];
        }

        public override void OnEnd()
        {
        }
    }
}
