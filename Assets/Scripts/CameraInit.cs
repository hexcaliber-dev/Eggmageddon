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
        StartCoroutine (DoZoom (initialZoom, finalZoom, zoomOutDelay, false));
    }

    // Update is called once per frame
    void Update () {
        if (followingPlayer) {
            if (GameObject.FindObjectOfType<Player> () != null)
                Camera.main.transform.position = GameObject.FindObjectOfType<Player> ().transform.position + new Vector3 (0, 0, -10);
            else
                Camera.main.transform.position = GameObject.FindGameObjectWithTag ("Marker").transform.position + new Vector3 (0, 0, -10);
        }
    }

    public IEnumerator DoZoom (float initial, float final, float delay, bool track) {
        yield return new WaitForSeconds (delay);
        int countup = 0;
        
        if (!track)
            followingPlayer = false;
        while (countup < RESOLUTION) {
            yield return new WaitForSeconds (zoomOutTime / RESOLUTION);
            Camera.main.orthographicSize = Mathf.Lerp (initial, final, (float) (countup) / RESOLUTION);

            if (!track)
                Camera.main.transform.position = new Vector3 (
                    Mathf.Lerp (Camera.main.transform.position.x, 0, (float) (countup) / RESOLUTION),
                    Mathf.Lerp (Camera.main.transform.position.y, 0, (float) (countup) / RESOLUTION), -10);
            countup += 1;
        }
    }

    public void EndgameZoom () {
        followingPlayer = true;
        StopAllCoroutines ();
        StartCoroutine (DoZoom (finalZoom, initialZoom, 0f, true));
    }
}