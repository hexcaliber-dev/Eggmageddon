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
    private float borderTopRight;
    private float borderBottomLeft;
    private float locationX;
    private float locationY;

    // Start is called before the first frame update
    void Start()
    {
        borderTopRight = topRightBorder.transform.position.x;
        borderBottomLeft = bottomLeftBorder.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
