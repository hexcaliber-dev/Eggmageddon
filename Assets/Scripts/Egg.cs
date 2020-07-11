using UnityEngine;

public abstract class Egg : MonoBehaviour {
    public const float maxSpeed = 5f;
    public const float accelRate = 3f,
        decelRate = 3f;
    public const int maxHealth = 3;

    public int currHealth;

    public GameObject[] deadEggs;

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

    public void Damage(int amount) {
        currHealth -= amount;
        if (currHealth == 1) {
            print("crack");
        } else if (currHealth <= 0) {
            GameObject.Instantiate(deadEggs[Random.Range(0, deadEggs.Length)], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}