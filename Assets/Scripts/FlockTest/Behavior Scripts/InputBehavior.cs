using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Flock/Behavior/Input")]
public class InputBehavior : FlockBehavior {


    public override Vector2 CalculateMove (FlockAgent agent, List<Transform> context, Flock flock) {

        Vector2 velocity = Vector2.zero;

        bool currentMove = false;
        if (Input.GetKey (KeyCode.W)) {
            velocity += new Vector2 (0, Egg.accelRate) * Time.deltaTime;
            currentMove = true;
        }
        if (Input.GetKey (KeyCode.A)) {
            velocity += new Vector2 (-Egg.accelRate, 0) * Time.deltaTime;
            currentMove = true;
        }
        if (Input.GetKey (KeyCode.D)) {
            velocity += new Vector2 (Egg.accelRate, 0) * Time.deltaTime;
            currentMove = true;
        }
        if (Input.GetKey (KeyCode.S)) {
            velocity += new Vector2 (0, -Egg.accelRate) * Time.deltaTime;
            currentMove = true;
        }
        if (velocity.magnitude > Egg.maxSpeed)
            velocity = velocity.normalized * Egg.maxSpeed;
        if (!currentMove)
            if (velocity.magnitude > Egg.decelRate * Time.deltaTime)
                velocity -= Egg.decelRate * velocity.normalized * Time.deltaTime;
            else
                velocity = Vector2.zero;

        return velocity;

    }
}