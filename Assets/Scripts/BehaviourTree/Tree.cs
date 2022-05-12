using System.Collections;
using UnityEngine;
using BehaviourTree.Nodes;

namespace BehaviourTree
{
    public abstract class Tree : MonoBehaviour
    {
        private const float TREE_UPDATE_FREQUENCY = 0.2f;
        private Node root;
        private bool updatingTree = true;

        // Start is called before the first frame update
        void Awake()
        {
            root = SetupTree();
            AIUpdater.Instance.SetCurrentNode(root);
            StartCoroutine(UpdateTree());
        }

        private IEnumerator UpdateTree()
        {
            var wait = new WaitForSeconds(TREE_UPDATE_FREQUENCY);
            while (updatingTree)
            {
                NodeState currentState = root.Evaluate();
                if (currentState == NodeState.Success)
                {
                    root.Reset();
                    AIUpdater.Instance.SetCurrentNode(root);
                }

                yield return wait;
            }
        }

        protected abstract Node SetupTree();
    }
}