using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    public abstract class Action : Node
    {
        protected Action(string name) : base(name, new List<Node>())
        {
        }
    }
}