using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    public class Control : Node
    {
        protected string treeId;
        
        public Control(string name, string treeId, List<Node> childrenNodes) : base(name, childrenNodes)

        {
            this.treeId = treeId;
        }
    }
}