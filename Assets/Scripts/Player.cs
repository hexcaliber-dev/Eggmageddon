// hello eggworld
using UnityEngine;

public class Player : Egg {

    Rigidbody2D rigidBody;

    new void Start() {
        base.Start();
        rigidBody = GetComponent<Rigidbody2D>();
        // instantiate references
    }
    
    public override void Move() {
        // Player movement
        //rigidBody.velocity /= 1.01f;
        
        bool currentMove = false;
        if (Input.GetKey(KeyCode.W)) {
            rigidBody.velocity += new Vector2(0, accelRate)*Time.deltaTime;
            currentMove = true;
        }
        if (Input.GetKey(KeyCode.A)) {
            rigidBody.velocity += new Vector2(-accelRate, 0)*Time.deltaTime;
            currentMove = true;
        }
        if (Input.GetKey(KeyCode.D)) {
            rigidBody.velocity += new Vector2(accelRate, 0)*Time.deltaTime;
            currentMove = true;
        }
        if (Input.GetKey(KeyCode.S)) {
            rigidBody.velocity += new Vector2(0, -accelRate)*Time.deltaTime;
            currentMove = true;
        }
        if (rigidBody.velocity.magnitude > maxSpeed)
            rigidBody.velocity = rigidBody.velocity.normalized*maxSpeed;
        if (!currentMove)
            if (rigidBody.velocity.magnitude > decelRate*Time.deltaTime)
                rigidBody.velocity -= decelRate*rigidBody.velocity.normalized*Time.deltaTime;
            else
                rigidBody.velocity = Vector2.zero;
    }
}