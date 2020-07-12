using UnityEngine;

public class MovementGenerator : MonoBehaviour {
    Animator anim;
    public enum Direction { north, west, south, east };

    void Start () {
        anim = GetComponent<Animator> ();
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

    public Direction GetDirection () {
        if (anim == null)
            anim = GetComponent<Animator>();
        return (Direction)anim.GetInteger("direction");
    }
}