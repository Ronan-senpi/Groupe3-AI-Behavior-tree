using System.Collections.Generic;
using UnityEngine;
using BehaviourTree.Nodes;
using Tree = BehaviourTree.Tree;

public class TestTree : Tree
{
    protected override Node SetupTree()
    {
        Debug.Log("Setup");
        Log log = new Log("Hello Tree!");
        Wait wait = new Wait(0.99f);
        Sequence sequence = new Sequence(new List<Node> { wait, log }, identifier);
        //Repeat repeat = new Repeat(sequence);
        return sequence;
    }
}