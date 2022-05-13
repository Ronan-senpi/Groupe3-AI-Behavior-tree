using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    /// <summary>
    /// Base class for condition nodes. Conditions are used to assure that future nodes can be executed.
    /// </summary>
    public abstract class Condition : Node
    {
        protected Condition(string name) : base(name, new List<Node>())
        {
        }
    }
}