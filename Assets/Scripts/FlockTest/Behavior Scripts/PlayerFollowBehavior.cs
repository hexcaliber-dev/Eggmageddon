using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Flock/Behavior/Follow Player")]
public class PlayerFollowBehavior : FlockBehavior {

    [Range (0f, 1f)]
    public float randomness;
    GameObject player;

    public override Vector2 CalculateMove (FlockAgent agent, List<Transform> context, Flock flock) {
        if (player == null) {
            if (Random.Range (0f, 1f) < randomness) {
                player = GameObject.FindObjectOfType<FlockAgent> ().gameObject;
            }
            else
                player = GameObject.FindObjectOfType<Player> ().gameObject;
        }

        float randomX = Random.Range (-randomness, randomness);
        float randomY = Random.Range (-randomness, randomness);
        return (Vector2) player.transform.position - (Vector2) agent.transform.position + new Vector2 (randomX, randomY);

    }
}