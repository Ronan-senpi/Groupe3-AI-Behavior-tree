using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{
    [SerializeField] [Range(25f, 1000f)] private float healthPoints = 750f;
    private float currentHeathPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHeathPoints = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
    }
}