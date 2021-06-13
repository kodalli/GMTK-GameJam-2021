using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/State/Dridd/IdleState")]
public class DriddIdleState : State<Dridd> {

    private float timeTillIdleEnd;
    public bool isIdleDone;

    public override void OnEnter(Dridd type) {
        timeTillIdleEnd = 2f;
        isIdleDone = false;
        type.RB.velocity = Vector2.zero;
        type.Flip();
    }

    public override void LogicUpdate(Dridd type) {
        type.Anim.Play("dridd_idle");
        timeTillIdleEnd -= Time.deltaTime;
        
        if (timeTillIdleEnd < 0.05f) {
            isIdleDone = true;
        }
    }

    public override void OnExit(Dridd type) {
    }
}