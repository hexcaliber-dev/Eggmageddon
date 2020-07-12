using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSystem : MonoBehaviour {

    public GameObject topRightBorder;
    public GameObject bottomLeftBorder;
    public GameObject missile;

    // Values decided within the game
    public float difficultyRate;
    public float difficultySize;
    public float difficultyScale;
    public static List<GameObject> currentExplosions;

    // Variables that will be changed within the code
    public float launchRate;
    public float launchClamp;
    private Vector2 borderTopRight;
    private Vector2 borderBottomLeft;
    private Vector2 location;
    private bool gameOngoing;

    // Start is called before the first frame update
    void Start () {
        print ("DIFFICULTY " + CONSTANTS.difficulty);
        difficultyScale = 1f / ((int) (CONSTANTS.difficulty) + 1);
        difficultyRate = 20 - ((int) (CONSTANTS.difficulty)) * 5;
        launchClamp = 1.0f / ((int) (CONSTANTS.difficulty) + 1);

        gameOngoing = true;
        currentExplosions = new List<GameObject> ();
        borderTopRight = new Vector2 (topRightBorder.transform.position.x, topRightBorder.transform.position.y);
        borderBottomLeft = new Vector2 (bottomLeftBorder.transform.position.x, bottomLeftBorder.transform.position.y);
        StartCoroutine (ConstantLaunching ());
        // Debug.Log(borderTopRight);
        // Debug.Log(borderBottomLeft);
    }

    // Update is called once per frame
    void Update () {

    }

    public Vector2 getLocation () {
        return location;
    }

    // mwehehehehe meerkatz - Omar and Akhil
    IEnumerator ConstantLaunching () {
        // Vector2 rp;
        while (gameOngoing) {
            location = randomPosition ();
            GameObject x = Instantiate (missile);
            AudioHelper.PlaySound ("missileincoming");
            currentExplosions.Add (x);
            x.transform.position = location;
            Debug.Log (currentExplosions.Count);
            Debug.Log ("Explosion X: " + x.GetComponent<Explosion> ().getX () + " Explsion YL " + x.GetComponent<Explosion> ().getY ());
            yield return new WaitForSeconds (launchRate);
            if (launchRate > launchClamp) {
                launchRate -= launchRate / (difficultyRate);
                difficultyRate += difficultyScale;
            }
            Debug.Log (launchRate);
        }
    }

    Vector2 randomPosition () {
        return new Vector2 (Random.Range (borderBottomLeft.x, borderTopRight.x), Random.Range (borderBottomLeft.y, borderTopRight.y));
    }

}