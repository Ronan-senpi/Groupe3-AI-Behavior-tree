using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    public abstract class Condition : Node
    {
        protected Condition(string name) : base(name, new List<Node>())
        {
        }
    }
}