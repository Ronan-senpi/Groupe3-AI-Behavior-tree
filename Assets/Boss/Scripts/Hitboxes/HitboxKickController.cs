using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxKickController : HitboxController
{
    public float ForceKickProjection { get; set; }

    protected override void customAction(HealthController fs)
    {
        fs.Rb.AddForce(transform.forward.normalized * ForceKickProjection, ForceMode.Impulse);
    }
}