using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// Logs with Debug.log when OnUpdate is called
    /// </summary>
    public class Log : Node
    {
        public string content;
        public Log(string logContent) : base(new List<Node>())
        {
            content = logContent;
        }

        public override void OnStart(){}

        public override NodeState OnUpdate()
        {
            Debug.Log(content);
            return NodeState.Success;
        }

        public override void OnEnd(){}
    }
}