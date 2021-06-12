using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/State/Dridd/IdleState")]
public class DriddIdleState : State<Dridd> {

    private float timeTillIdleEnd;
    public bool isIdleDone;
    public bool playerDetected;
    
    public override void OnEnter(Dridd type) {
        timeTillIdleEnd = 2f;
        isIdleDone = false;
        playerDetected = false;
        type.RB.velocity = Vector2.zero;
        type.Flip();
    }

    public override void LogicUpdate(Dridd type) {
        type.Anim.Play("dridd_idle");
        timeTillIdleEnd -= Time.deltaTime;

        var isDetectingPlayer = type.IsDetectingPlayer();
        playerDetected = isDetectingPlayer;
        if (playerDetected) {
            Debug.Log("player detected");
        }
        
        if (timeTillIdleEnd < 0.05f) {
            isIdleDone = true;
        }
    }

    public override void OnExit(Dridd type) {
    }
}