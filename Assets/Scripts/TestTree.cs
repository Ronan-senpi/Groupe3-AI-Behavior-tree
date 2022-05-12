using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using Tree = BehaviourTree.Tree;

public class TestTree : Tree
{
    protected override Node SetupTree()
    {
        Debug.Log("Setup");
        Log log = new Log("Hello Tree!");
        Wait wait = new Wait(3);
        Sequence sequence = new Sequence(new List<Node>{wait,log});
        //Repeat repeat = new Repeat(sequence);
        return sequence;
    }
}
