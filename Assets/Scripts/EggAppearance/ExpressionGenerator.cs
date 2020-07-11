using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionGenerator : MonoBehaviour {

    // Goes in the order: happy, neutral, angry, scared
    public List<Sprite> west, south, east;

    public enum Emotion { Happy, Neutral, Angry, Scared }
    public enum Direction { north, west, south, east }

    SpriteRenderer rend;
    Animator anim;

    // Start is called before the first frame update
    void Start () {
        rend = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator> ();
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

    public void SetDirection (Vector2 dir) {
        float x = dir.x, y = dir.y;
        if (Mathf.Abs (x) > Mathf.Abs (y)) {
            if (x > 0) {
                anim.SetInteger ("direction", (int) Direction.east);
            } else {
                anim.SetInteger ("direction", (int) Direction.west);
            }
        } else {
            if (y > 0) {
                anim.SetInteger ("direction", (int) Direction.north);
            } else {
                anim.SetInteger ("direction", (int) Direction.south);
            }
        }
    }
}