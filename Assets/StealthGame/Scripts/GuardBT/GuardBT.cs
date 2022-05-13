using System.Collections;
using System.Collections.Generic;
using BehaviourTree.Nodes;
using UnityEngine;
using Tree = BehaviourTree.Tree;

public class GuardBT : Tree
{
    protected override Node SetupTree()
    {
        ActionGoTowardPlayer goTowardPlayer = new ActionGoTowardPlayer(6f);
        Sequence sequence = new Sequence(new List<Node> { goTowardPlayer });

        Selector selec = new Selector(new List<Node>{sequence});

        return selec;
    }
}
