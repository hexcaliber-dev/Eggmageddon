using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public AudioClip intro, loop;
    // Start is called before the first frame update
    void Start () {
        StartCoroutine(StartLoop());
    }

    // Update is called once per frame
    void Update () {

    }

    IEnumerator StartLoop() {
        yield return new WaitForSeconds(intro.length - 1.5f);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = loop;
        GetComponent<AudioSource>().Play();

    }
}