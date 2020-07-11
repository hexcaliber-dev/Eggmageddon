using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Flock/Behavior/Follow Player")]
public class PlayerFollowBehavior : FlockBehavior {

    public float randomness;

    public override Vector2 CalculateMove (FlockAgent agent, List<Transform> context, Flock flock) {
        float randomX = Random.Range(-randomness, randomness);
        float randomY = Random.Range(-randomness, randomness);
        return (Vector2)GameObject.FindObjectOfType<Player>().transform.position - (Vector2) agent.transform.position + new Vector2(randomX, randomY);

    }
}
