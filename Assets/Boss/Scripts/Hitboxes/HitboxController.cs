using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class HitboxController : MonoBehaviour
{
    public float Duration { get; set; } = 1f;
    public float Damage { get; set; }
    public LayerMask TargetMask { get; set; }
    private void OnEnable()
    {
        StartCoroutine(Desactivate());
    }

    IEnumerator Desactivate()
    {
        yield return new WaitForSeconds(Duration);
        gameObject.SetActive(false);
    }

    protected virtual void customAction(FightScript fs)
    {
        
    } 
    private void OnTriggerEnter(Collider other)
    {
        //Compare sur les bit et non sur la text plus rapide
        if ((TargetMask.value & (1 << other.gameObject.layer)) > 0)
        {
          FightScript  fs = other.gameObject.GetComponent<FightScript>();
          if (fs != null && fs.Rb != null)
          {
              customAction(fs);
              fs.TakeDamage(Damage);
          }
        }
    }
}
