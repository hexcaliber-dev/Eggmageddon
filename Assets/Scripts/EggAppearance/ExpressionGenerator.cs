using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionGenerator : MonoBehaviour {

    // Goes in the order: happy, neutral, angry, scared
    public List<Sprite> north, west, south, east;

    public enum Emotion { Happy, Neutral, Angry, Scared }

    SpriteRenderer rend;
    bool emoting;

    public MovementGenerator movement;

    // Start is called before the first frame update
    void Start () {
        rend = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update () {
        if (!emoting) {
            rend.sprite = getSpriteList()[0];
        }
    }

    public void SetEmotion (Emotion emote, float seconds) {
        StartCoroutine (cEmotion (emote, seconds));
    }

    IEnumerator cEmotion (Emotion emote, float seconds) {
        emoting = true;
        rend.sprite = getSpriteList()[(int)emote];
        yield return new WaitForSeconds (seconds);
        emoting = false;
    }

    List<Sprite> getSpriteList () {
        MovementGenerator.Direction dir = movement.GetDirection ();
        if (dir == MovementGenerator.Direction.west) {
            return west;
        } else if (dir == MovementGenerator.Direction.east) {
            return east;
        } else if (dir == MovementGenerator.Direction.south) {
            return south;
        }
        return north;
    }
}