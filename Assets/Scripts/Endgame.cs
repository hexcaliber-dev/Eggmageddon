using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour {

    // Camera cam;
    // int zoom = 20;
    // int norm = 60;
    // float speed = 5;

    // public GameObject player;

    enum state {restart, mainMenu}

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 0;
        //cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    //Zooming into player death location after death (unneeded?)
    // public void DeathZoom() {
    //     cam.transform.position = Vector2.MoveTowards(cam.transform.position, player.transform.position, speed * Time.deltaTime);
    //     cam.fieldOfView = Vector2.Lerp(cam.fieldOfView, zoom, speed * Time.deltaTime);
    // }

    public void GameOverMenu() {

    }
}
