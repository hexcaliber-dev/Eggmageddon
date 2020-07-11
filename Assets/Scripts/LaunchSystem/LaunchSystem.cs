using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSystem : MonoBehaviour
{

    public GameObject topRightBorder;
    public GameObject bottomLeftBorder;

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

    // Start is called before the first frame update
    void Start()
    {
        borderTopRight = new Vector2(topRightBorder.transform.position.x, topRightBorder.transform.position.y);
        borderBottomLeft = new Vector2(bottomLeftBorder.transform.position.x, bottomLeftBorder.transform.position.y);
        // Debug.Log(borderTopRight);
        // Debug.Log(borderBottomLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
