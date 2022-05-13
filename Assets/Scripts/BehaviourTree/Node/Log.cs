using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    /// <summary>
    /// Logs with Debug.log when OnUpdate is called
    /// </summary>
    public class Log : Action
    {
        public string content;

        public Log(string logContent) : base("Log")
        {
            content = logContent;
        }

        public override void OnUpdate(float elapsedTime)
        {
            Debug.Log(content);
            state = NodeState.Success;
        }
    }
}