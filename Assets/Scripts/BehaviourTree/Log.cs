using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// Logs with Debug.log when OnUpdate is called
    /// </summary>
    public class Log : Action
    {
        public string content;
        public Log(string logContent) : base(new List<Node>())
        {
            content = logContent;
        }

        public override void OnStart(){}

        public override NodeState Evaluate()
        {
            Debug.Log("Evaluate de Log");
            return base.Evaluate();
        }

        public override void OnUpdate()
        {
            Debug.Log("OnUpdate LOG");
            Debug.Log(content);
            state = NodeState.Success;
        }
        
        public override void OnEnd(){}
    }
}