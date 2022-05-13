using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    /// <summary>
    /// Base class for Control nodes. Control nodes are used to update the state of corresponding AI.
    /// They can either be selectors or sequences
    /// </summary>
    public abstract class Control : Node
    {
        protected string treeId;
        
        public Control(string name, string treeId, List<Node> childrenNodes) : base(name, childrenNodes)

        {
            this.treeId = treeId;
        }
    }
}