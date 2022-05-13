using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 pos;
    public Dictionary<string, int> data;

    private void Awake()
    {
        pos = transform.position;    
    }
    
}
