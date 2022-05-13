using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree.Nodes;
using Tree = BehaviourTree.Tree;

public class BossTree : Tree
{
    [SerializeField] private BossController boss;
    protected override Node SetupTree()
    {
        CheckBetween checkDist = new CheckBetween(boss.transform, boss.Target, boss.SwordRange);
        AttackSword attackSword = new AttackSword(boss);
        ReachPlayer reachPlayer = new ReachPlayer(boss, boss.Target);

        Sequence attackSequence = new Sequence(new List<Node>() { checkDist, attackSword }, identifier);
        Selector bossSelector = new Selector(new List<Node>() { attackSequence, reachPlayer }, identifier);

        return bossSelector;
    }
}