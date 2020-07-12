using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryGenerator : MonoBehaviour
{

    public List<GameObject> hats;
    public int currHat;
    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(0, hats.Count + 2);
        if (r <= hats.Count-1) {
            hats[r].SetActive(true);
            currHat = r;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetCurrHat() {
        print(hats[currHat].GetComponent<SpriteRenderer>().sprite);
        return hats[currHat].GetComponent<SpriteRenderer>().sprite;
    }
}
