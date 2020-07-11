using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryGenerator : MonoBehaviour
{

    public List<GameObject> hats;
    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(0, hats.Count);
        if (r <= hats.Count-1) {
            hats[r].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
