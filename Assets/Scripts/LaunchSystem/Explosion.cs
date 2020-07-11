using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Explosion : MonoBehaviour
{

    public float getX()
    {
        return transform.position.x;
    }

    public float getY()
    {
        return transform.position.y;
    }
    
    public Vector2 getLocation()
    {
        return new Vector2( transform.position.x, transform.position.y); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        applyAffect( collision.gameObject );
    }

    public abstract void applyAffect(GameObject unit);

}
