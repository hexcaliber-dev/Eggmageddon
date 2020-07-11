using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (Collider2D))]
public class FlockAgent : MonoBehaviour {

    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }
    public Transform eggSprites;
    public MovementGenerator movement;
    public GameObject expression;

    // Start is called before the first frame update
    void Start () {
        agentCollider = GetComponent<Collider2D> ();
    }

    public void Initialize (Flock flock) {
        agentFlock = flock;
    }

    public void Move (Vector2 velocity) {
        transform.up = velocity;
        float heading = Mathf.Atan2 (velocity.x, velocity.y);
        eggSprites.rotation = Quaternion.Euler(new Vector3(0, 0, heading));
        transform.position += (Vector3) velocity * Time.deltaTime;
        movement.SetDirection(velocity);
    }

    public void changeExpression(ExpressionGenerator.Emotion emo, float seconds)
    {
        expression.GetComponent<ExpressionGenerator>().SetEmotion(emo, seconds);
    }
}