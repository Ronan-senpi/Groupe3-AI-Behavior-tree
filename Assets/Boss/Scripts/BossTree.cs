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
        CheckBetween checkSwordDist = new CheckBetween(boss.transform, boss.Target, boss.SwordRange);
        CheckBetween checkKickDist = new CheckBetween(boss.transform, boss.Target, boss.KickRange);
        CheckBetween checkSpellDist = new CheckBetween(boss.transform, boss.Target, boss.SpellRange);

        AttackSword slash = new AttackSword(boss);
        AttackKick kick = new AttackKick(boss);
        AttackSpell spell = new AttackSpell(boss);

        ReachPlayer reachPlayer = new ReachPlayer(boss, boss.Target);

        Sequence kickSequence = new Sequence(new List<Node>() { checkKickDist, kick }, identifier);
        Sequence slashSequence = new Sequence(new List<Node>() { checkSwordDist, slash }, identifier);
        Sequence spellSequence = new Sequence(new List<Node>() { checkSpellDist, spell }, identifier);

        Selector bossSelector =
            new Selector(new List<Node>() { kickSequence, slashSequence, spellSequence, reachPlayer }, identifier);

        return bossSelector;
    }
}