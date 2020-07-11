using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionGenerator : MonoBehaviour {

    // Goes in the order: happy, neutral, angry, scared
    public List<Sprite> west, south, east;

    public enum Emotion { Happy, Neutral, Angry, Scared };

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start () {
        rend = GetComponent<SpriteRenderer> ();
        
    }

    // Update is called once per frame
    void Update () {

    }

    public void SetEmotion (Emotion emote, float seconds) {
        StartCoroutine (cEmotion (emote, seconds));
    }

    IEnumerator cEmotion (Emotion emote, float seconds) {
        yield return new WaitForSeconds (seconds);
    }
}