using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Flock/Behavior/Stay In Box")]
public class StayInBoxBehavior : FlockBehavior {
    public Vector2 center;
    public Vector2[] wallNodes;
    public float minDistance;

    public override Vector2 CalculateMove (FlockAgent agent, List<Transform> context, Flock flock) {
        foreach (Vector2 wall in wallNodes) {
            Vector2 offset = wall - (Vector2) agent.transform.position;
            if (offset.magnitude < minDistance) {
                return center - (Vector2) agent.transform.position;
            }
        }
        return Vector2.zero;
    }
}