using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 pos;

    private void Awake()
    {
        pos = transform.position;
    }
}
