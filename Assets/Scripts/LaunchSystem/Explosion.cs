using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Explosion : MonoBehaviour
{

    public float sizeLimit;
    public float rateOfSizeOfIncrease;
    public float detonationDelay;
    private bool increasing;
    

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

    void Awake ()
    {
        increasing = true;
    }

    public void FixedUpdate()
    {
        Debug.Log(increasing);
        if (increasing)
        {
            increaseSize();
        }
        if(this.transform.localScale.x >= sizeLimit)
        {
            increasing = false;
            StartCoroutine(startMassacre());            
        }
    }

    IEnumerator startMassacre()
    {
        yield return new WaitForSeconds(detonationDelay);
        Destroy(gameObject);
    }

    void increaseSize() {this.transform.localScale += new Vector3(rateOfSizeOfIncrease, rateOfSizeOfIncrease, 0);}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        applyAffect( collision.gameObject );
    }

    public abstract void applyAffect(GameObject unit);

}
