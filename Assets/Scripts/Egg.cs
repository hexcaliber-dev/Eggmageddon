using UnityEngine;

public abstract class Egg : MonoBehaviour {
    public const float maxSpeed = 5f;
    public const float accelRate = 3f,
        decelRate = 3f;
    public const int maxHealth = 3;

    public int currHealth;

    public virtual void Start () {
        currHealth = maxHealth;
    }
    public abstract void Move ();

    public virtual void Update () {
        Move ();
    }

    void OnCollisionEnter2D (Collision2D col) {
        // Handle missile collisions TODO
        // Possibly powerup collisions too
    }
}