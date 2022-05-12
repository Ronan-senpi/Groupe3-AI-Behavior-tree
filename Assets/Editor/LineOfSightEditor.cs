using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LineOfSight))]
public class LineOfSightEditor : Editor
{
    protected virtual void OnSceneGUI()
    {
        LineOfSight los = (LineOfSight)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(
            los.transform.position,
            Vector3.up,
            los.transform.forward,
            360,
            los.ViewRadius
            );
        Vector3 viewAngleA = los.DirFromAngle(-los.ViewAngle / 2, false);
        
        Vector3 viewAngleB = los.DirFromAngle(los.ViewAngle / 2, false);
        
        Handles.DrawLine(los.transform.position, los.transform.position + viewAngleA * los.ViewRadius);
        Handles.DrawLine(los.transform.position, los.transform.position + viewAngleB * los.ViewRadius);
    }
}
