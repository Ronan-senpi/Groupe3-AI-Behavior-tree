using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BossController : MonoBehaviour
{

    [Header("Kick")] 
    [SerializeField] 
    private float distanceKick = 5f;
    private float distanceKickProjection = 5f;
    private float kickDamages = 2.5f;
    
    [Header("Sword")] 
    [SerializeField] 
    private float distanceSword = 10f;
    private float sowrdDamages = 5f;

    [Header("Spell")] 
    [SerializeField] 
    private float distanceSpell = 20f;
    private float spellDamages = 5f;
    
    
    
    void AttackCastSpell()
    {
        
    }

    void AttackKick()
    {
        
    }

    void AttackSword()
    {
        
    }
    
    void RunToPlayer()
    {
        
    }
    
}
