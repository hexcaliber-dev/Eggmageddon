using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : Explosion
{

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
        Destroy(unit);
        Debug.Log("Object Destroyed");
    }

}
