using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField] protected float viewRadius;
    public float ViewRadius => viewRadius;
    [SerializeField] [Range(0f,360f)] protected float viewAngle;
    public float ViewAngle => viewAngle;



    public virtual Vector3 DirFromAngle(float angleInDegree, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
            angleInDegree += transform.eulerAngles.y;
        return new Vector3(
            Mathf.Sin(angleInDegree * Mathf.Deg2Rad),
            0,
            Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
    }
}
