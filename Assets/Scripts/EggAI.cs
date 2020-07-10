// hello eggworld
using UnityEngine;

public class EggAI : Egg {

    public enum AIState {Idle, RunningAway, RunningTowards, Dead};

    void Start () {
        base.Start ();
        // instantiate references
    }

    public override void Move () {
        // AI movement
    }
}
