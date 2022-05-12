using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class Action : Node
    {
        protected Action(List<Node> childrenNodes) : base(childrenNodes)
        {
        }
    }
}