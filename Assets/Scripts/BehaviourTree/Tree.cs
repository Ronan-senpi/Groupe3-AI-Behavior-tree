using System.Collections;
using UnityEngine;
using BehaviourTree.Nodes;
using Unity.VisualScripting;

namespace BehaviourTree
{
    /// <summary>
    /// Base class that contains the generic property of a tree
    /// </summary>
    public abstract class Tree : MonoBehaviour
    {
        [Tooltip("Time in seconds between each update of the tree")] [SerializeField]
        private float treeUpdateFrequency = 0.2f;

        [Tooltip("Identifier for the AI")]
        [SerializeField] protected string identifier;
        private Node root;
        private bool updatingTree = true;

        // Start is called before the first frame update
        protected void Awake()
        {
            root = SetupTree();
            AIUpdater.Instance.SetCurrentNode(identifier, root);
            StartTree();
        }

        private IEnumerator UpdateTree()
        {
            var wait = new WaitForSeconds(treeUpdateFrequency);
            while (updatingTree)
            {
                NodeState currentState = root.Evaluate();
                if (currentState == NodeState.Success)
                {
                    ResetTree();
                }

                yield return wait;
            }
        }

        /// <summary>
        /// A function that set the tree to its original state
        /// </summary>
        public void ResetTree()
        {
            root.Reset();
            AIUpdater.Instance.SetCurrentNode(identifier, root);
        }


        /// <summary>
        /// A function to set up the tree at launch. This is where we need to create every selectors, sequences, actions & conditions
        /// </summary>
        /// <returns>The highest node on the tree which will be used as the root</returns>
        protected abstract Node SetupTree();


        /// <summary>
        /// A function that stop the update of the tree
        /// </summary>
        public void StopTree()
        {
            updatingTree = false;
            StopCoroutine(UpdateTree());
        }

        /// <summary>
        /// A function to start the update of the tree
        /// </summary>
        public void StartTree()
        {
            updatingTree = true;
            StartCoroutine(UpdateTree());
        }
    }
}