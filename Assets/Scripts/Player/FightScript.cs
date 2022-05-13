using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FightScript : MonoBehaviour
{
    [SerializeField] [Range(25f, 1000f)] private float healthPoints = 750f;
    
    [SerializeField][Range(0f, 1000f)]
    private float currentHeathPoints;
    public Rigidbody Rb { get; private set; }
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHeathPoints = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float damage)
    {
        currentHeathPoints -= damage;
    }
}