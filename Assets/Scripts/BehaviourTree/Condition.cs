using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class Condition : Node
    {
        protected Condition(List<Node> childrenNodes) : base(childrenNodes)
        {
        }
    }
}