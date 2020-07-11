// hello eggworld
using UnityEngine;

public class EggAI : Egg {

    public enum AIState {Idle, RunningAway, RunningTowards, Dead};

    public AIState currState;

    public override void Start () {
        base.Start ();
        // instantiate references
        currState = AIState.Idle;
    }

    public override void Move () {
        // AI movement
        if (currState == AIState.Idle) {
            
        }
    }
}
