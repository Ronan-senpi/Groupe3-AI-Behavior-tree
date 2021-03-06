using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree.Nodes;
using Tree = BehaviourTree.Tree;

public class BossTree : Tree
{
    [SerializeField] private BossController boss;
    [SerializeField] private HealthController bossHealth;

    protected void Awake()
    {
        base.Awake();
        boss = GetComponent<BossController>();
        bossHealth = GetComponent<HealthController>();
    }

    protected override Node SetupTree()
    {
        CompareIsInferior comparison = new CompareIsInferior(bossHealth,
            bossHealth.HealthPoints * boss.PowerUpThreshold);
        IsAlreadyPowerUp powerUpState = new IsAlreadyPowerUp(boss);

        PowerUp powerUp = new PowerUp(boss);

        Sequence powerUpSequence = new Sequence(new List<Node>() { comparison, powerUpState, powerUp }, identifier);

        CheckBetween checkSwordDist = new CheckBetween(boss.transform, boss.Target, boss.SwordRange);
        CheckBetween checkKickDist = new CheckBetween(boss.transform, boss.Target, boss.KickRange);
        CheckBetween checkSpellDist = new CheckBetween(boss.transform, boss.Target, boss.SpellRange);

        Attack slash = new Attack(boss, boss.HitboxSword, AnimationNames.Slash);
        Attack kick = new Attack(boss, boss.HitboxKick, AnimationNames.Kick);
        Attack spell = new Attack(boss, boss.HitboxSpell, AnimationNames.Spell);

        ReachPlayer reachPlayer = new ReachPlayer(boss, boss.Target);

        Sequence kickSequence = new Sequence(new List<Node>() { checkKickDist, kick }, identifier);
        Sequence slashSequence = new Sequence(new List<Node>() { checkSwordDist, slash }, identifier);
        Sequence spellSequence = new Sequence(new List<Node>() { checkSpellDist, spell }, identifier);

        Selector bossSelector =
            new Selector(new List<Node>() { powerUpSequence, kickSequence, slashSequence, spellSequence, reachPlayer },
                identifier);

        return bossSelector;
    }
}