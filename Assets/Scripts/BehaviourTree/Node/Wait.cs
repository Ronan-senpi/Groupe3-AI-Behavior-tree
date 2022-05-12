using System.Collections;
using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

namespace BehaviourTree.Nodes
{
    public class Wait : Action
    {
        private float currentTimer;
        private float waitTimer;

        public Wait(float waiting) : base("Wait")
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
            return state;
        }
        public override void OnUpdate(float elapsedTime)
        {
            //Debug.Log("OnUpdate du WAIT : currentTimer = " + currentTimer + " and max time = " + waitTimer);
            currentTimer += elapsedTime;
            if (currentTimer >= waitTimer)
            {
                state = NodeState.Success;
            }
            else
            {
                state = NodeState.Running;
            }

        }


        public override void OnEnd()
        {
            currentTimer = 0;
        }
    }
}