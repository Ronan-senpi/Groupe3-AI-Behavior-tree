using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BossController))]
public class BossLinesOfSightEditor: LineOfSightEditor 
{
    protected virtual void OnSceneGUI()
    {
        BossController los = (BossController)target;
        //Kick
        
        drawRangeLOS(los.KickColor, los.transform.position, los.transform.forward, los.KickRange);
        drawRangeLOS(los.SpellColor, los.transform.position, los.transform.forward, los.SpellRange);
        drawRangeLOS(los.SwordColor, los.transform.position, los.transform.forward, los.SwordRange);
            
        Handles.color = Color.white;
        
        Vector3 viewAngleA = los.DirFromAngle(-los.ViewAngle / 2, false);
        Vector3 viewAngleB = los.DirFromAngle(los.ViewAngle / 2, false);
        
        Handles.DrawLine(los.transform.position, los.transform.position + viewAngleA * los.ViewRadius);
        Handles.DrawLine(los.transform.position, los.transform.position + viewAngleB * los.ViewRadius);

    }

    private void drawRangeLOS(Color c, Vector3 center, Vector3 dir, Vector2 range)
    {
        Handles.color = c;
        //near
        Handles.DrawWireArc(
            center,
            Vector3.up,
            dir,
            360,
            range.x);
        // far
        Handles.DrawWireArc(
            center,
            Vector3.up,
            dir,
            360,
            range.y);
        

    }
}
