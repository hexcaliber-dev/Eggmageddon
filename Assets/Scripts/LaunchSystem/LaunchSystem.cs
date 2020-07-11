using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSystem : MonoBehaviour
{

    public GameObject topRightBorder;
    public GameObject bottomLeftBorder;
    public GameObject missile;

    // Values decided within the game
    public float difficultyRate;
    public float difficultySize;

    // Variables that will be changed within the code
    private float launchRate;
    private float launchSize;
    private Vector2 borderTopRight;
    private Vector2 borderBottomLeft;
    private float locationX;
    private float locationY;
    private bool gameOngoing;

    // Start is called before the first frame update
    void Start()
    {
        gameOngoing = true;
        borderTopRight = new Vector2(topRightBorder.transform.position.x, topRightBorder.transform.position.y);
        borderBottomLeft = new Vector2(bottomLeftBorder.transform.position.x, bottomLeftBorder.transform.position.y);
        StartCoroutine(ConstantLaunching());
        // Debug.Log(borderTopRight);
        // Debug.Log(borderBottomLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator ConstantLaunching()
    {
        Vector2 rp;
        while (gameOngoing)
        {
            rp = randomPosition();
            GameObject x = Instantiate(missile);
            x.transform.position = rp;
            Debug.Log("Explosion X: " + x.GetComponent<Explosion>().getX() + " Explsion YL " + x.GetComponent<Explosion>().getY());
            yield return new WaitForSeconds(difficultyRate);
        }
    }


    Vector2 randomPosition()
    {
        return new Vector2(Random.Range(borderBottomLeft.x, borderTopRight.x), Random.Range(borderBottomLeft.y, borderTopRight.y));
    }


}
