using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State/Dridd/MoveState")]
public class DriddMoveState : State<Dridd> {

    private float timeLeftInMove;
    public bool isMovingDone;
    public bool playerDetected;
    public override void OnEnter(Dridd type) {
        timeLeftInMove = 4f;
        isMovingDone = false;
        playerDetected = false;
    }

    public override void LogicUpdate(Dridd type) {
        type.Anim.Play("dridd_run");
        type.RB.velocity = new Vector2(type.movementSpeed * type.FacingDirection, type.currentVelocity.y);
        timeLeftInMove -= Time.deltaTime;

        var isDetectingPlayer = type.IsDetectingPlayer();
        playerDetected = isDetectingPlayer;
        if (playerDetected) {
            Debug.Log("player detected");
        }
        
        if (timeLeftInMove < 0.05f) {
            isMovingDone = true;
        }

    }

    public override void OnExit(Dridd type) {
    }
}