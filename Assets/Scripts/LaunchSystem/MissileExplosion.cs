using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : Explosion
{

    public float outerExplosionRadius;
    public float innerExplosionRadius;
    private float sizeIncreaseScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(sizeIncreaseScale, sizeIncreaseScale, 0);
    }

    public override void applyAffect(GameObject unit)
    {
        if (unit.tag == "Egg")
        {
            // 
            if (Vector2.Distance(transform.position, unit.transform.position) < outerExplosionRadius)
            {
                if(Vector2.Distance(transform.position, unit.transform.position) < innerExplosionRadius)
                {
                    Debug.Log("Egg Severley Damaged");
                    // unit.GetComponent<Egg>().Damage(1);
                }
                // unit.GetComponent<Egg>().Damage(1);
            }
            Debug.Log("Egg Damaged");
        }
    }

}
