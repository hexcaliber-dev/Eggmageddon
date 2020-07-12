using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInit : MonoBehaviour {

    public float zoomOutDelay, zoomOutTime, initialZoom, finalZoom;
    bool followingPlayer;

    public int RESOLUTION = 20;

    // Start is called before the first frame update
    void Start () {
        followingPlayer = true;
        Camera.main.orthographicSize = initialZoom;
        StartCoroutine (DoZoom ());
    }

    // Update is called once per frame
    void Update () {
        if (followingPlayer) {
            Camera.main.transform.position = GameObject.FindObjectOfType<Player> ().transform.position + new Vector3(0, 0, -10);
        }
    }

    IEnumerator DoZoom () {
        yield return new WaitForSeconds (zoomOutDelay);
        int countup = 0;
        followingPlayer = false;
        while (countup < RESOLUTION) {
            yield return new WaitForSeconds (zoomOutTime / RESOLUTION);
            Camera.main.orthographicSize = Mathf.Lerp (initialZoom, finalZoom, (float) (countup) / RESOLUTION);
            Camera.main.transform.position = new Vector3 (
                Mathf.Lerp (Camera.main.transform.position.x, 0, (float) (countup) / RESOLUTION),
                Mathf.Lerp (Camera.main.transform.position.y, 0, (float) (countup) / RESOLUTION), -10);
            countup += 1;
        }
    }
}