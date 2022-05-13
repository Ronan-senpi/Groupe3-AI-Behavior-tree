using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HitboxController : MonoBehaviour
{
    public float? Duration { get; set; }
    public float Damage { get; set; }
    public LayerMask TargetMask { get; set; }
    public Collider Col { get; set; }
    private void Awake()
    {
        Col = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        if(Duration.HasValue)
            StartCoroutine(Desactivate());
    }

    IEnumerator Desactivate()
    {
        yield return new WaitForSeconds(Duration.Value);
        gameObject.SetActive(false);
    }

    protected virtual void customAction(HealthController fs)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //Compare sur les bit et non sur la text plus rapide
        if ((TargetMask.value & (1 << other.gameObject.layer)) > 0)
        {
            HealthController hc = other.gameObject.GetComponent<HealthController>();
            if (hc != null)
            {
                customAction(hc);
                hc.Impact(Damage);
            }
        }
    }
}