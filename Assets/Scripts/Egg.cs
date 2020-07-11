using UnityEngine;

public abstract class Egg : MonoBehaviour {
    public const float maxSpeed = 1;
    public const float accelRate = 0.5f,
        decelRate = 0.5f;
    public const int maxHealth = 3;

    public int currHealth;

    public void Start () {
        currHealth = maxHealth;
    }
    public abstract void Move ();

    public void Update () {
        Move ();
    }

    void OnCollisionEnter2D (Collision2D col) {
        // Handle missile collisions TODO
        // Possibly powerup collisions too
    }
}