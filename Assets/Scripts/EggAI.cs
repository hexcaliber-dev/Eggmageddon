// hello eggworld
using UnityEngine;

public class EggAI : Egg {

    public ExpressionGenerator expressions;

    public override void Start () {
        base.Start ();
    }

    public override void Move () {
        expressions.SetDirection(GetComponent<Rigidbody2D>().velocity);
        // AI movement is handled by flock behaviors.
    }
}
