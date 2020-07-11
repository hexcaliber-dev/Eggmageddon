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
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        applyAffect( collision.gameObject );
    }

    public abstract void applyAffect(GameObject unit);

}
