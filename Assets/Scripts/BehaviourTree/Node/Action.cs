using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    /// <summary>
    /// Base class for Action node. This node will execute the acion of the AI.
    /// </summary>
    public abstract class Action : Node
    {
        protected Action(string name) : base(name, new List<Node>())
        {
        }
    }
}