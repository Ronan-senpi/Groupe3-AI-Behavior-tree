using System.Collections;
using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

namespace BehaviourTree
{
    public class Wait : Action
    {
        private float currentTimer;
        private float waitTimer;

        public Wait(float waiting) : base(new List<Node>())
        {
            waitTimer = waiting;
            OnStart();
        }


        public override void OnStart()
        {
            currentTimer = 0;
        }

        public override NodeState Evaluate()
        {
            Debug.Log("Evaluate de Wait");
            return base.Evaluate();
        }
        public override void OnUpdate()
        {
            Debug.Log("OnUpdate du WAIT");
            currentTimer += Time.deltaTime;
            if (currentTimer > waitTimer)
            {
                state = NodeState.Success;
            }

            state = NodeState.Running;
        }


        public override void OnEnd()
        {
            currentTimer = 0;
        }
    }
}