using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float speed = 5;
    public float waitTime = .3f;

    public Transform pathHolder;

    void Start(){
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for(int i = 0 ; i < waypoints.Length; i++){
            waypoints[i] = pathHolder.GetChild(i).position;
        }
    }

    /*IEnumerator FollowPath(Vector3[] waypoints){
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        while(true){

        }

        return 0;
    }*/

    void OnDrawGizmos() {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;
        foreach(Transform waypoint in pathHolder){
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.color = Color.black;
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);
    }
}
