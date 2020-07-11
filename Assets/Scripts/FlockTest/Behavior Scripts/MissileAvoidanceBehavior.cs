using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Missile Avoidance")]
public class MissileAvoidanceBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
       GameObject[] missiles = GameObject.FindGameObjectsWithTag("Explosion");

       Vector2 trajectory = Vector2.zero;

       foreach(GameObject m in missiles) {
           Vector2 dir = (Vector2)(agent.transform.position - m.transform.position);
           dir.Normalize();
           trajectory += dir;
       }

       return trajectory;
    }
}
