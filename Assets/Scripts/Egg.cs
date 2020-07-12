using UnityEngine;

public abstract class Egg : MonoBehaviour {
    public const float maxSpeed = 5f;
    public const float accelRate = 7f,
        decelRate = 7f;
    public const int maxHealth = 3;

    public int currHealth;
    public GameObject marker;
    public GameObject[] deadEggs;

    private Rigidbody2D body;

    public virtual void Start()
    {
        currHealth = maxHealth;
        body = GetComponent<Rigidbody2D>();
        gameObject.tag = "Egg";
    }

    public abstract void Move();

    public virtual void Update()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 currentPos = transform.position;
        int scale = 1000;

        if (col.gameObject.CompareTag("Egg"))
        {
            Vector2 knockback = (Vector2)col.transform.position - currentPos; //knockback direction
            if (body != null)
                body.AddForce(knockback * scale);
        }

        // Handle missile collisions TODO
        // Possibly powerup collisions too
    }

    public void Damage(int amount) {
        currHealth -= amount;
        if (currHealth == 1) {
            print("crack");
        } else if (currHealth <= 0) {
            GameObject.Instantiate(deadEggs[Random.Range(0, deadEggs.Length)], transform.position, Quaternion.identity);
            if (gameObject.GetComponent<Player>() != null)
            {
                GameObject.Instantiate(marker, transform.position + new Vector3(0f, 0f, -3f), Quaternion.identity);
            }
            GameObject.FindObjectOfType<HUD>().UpdateRemainingEggs(GameObject.FindGameObjectsWithTag("Egg").Length);
            Destroy(gameObject);
        }
    }
}