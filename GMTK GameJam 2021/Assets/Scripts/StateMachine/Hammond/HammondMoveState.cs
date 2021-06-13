using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State/Hammond/MoveState")]
public class HammondMoveState : State<Hammond> {
    private float timeLeftInMove;
    public bool isMovingDone;
    public bool playerDetected;

    public override void OnEnter(Hammond type) {
        timeLeftInMove = 4f;
        isMovingDone = false;
        playerDetected = false;
    }

    public override void LogicUpdate(Hammond type) {
        timeLeftInMove -= Time.deltaTime;

        type.anim.Play("hammond_run");
        type.rb.velocity = new Vector2(type.movementSpeed * type.facingDirection, type.currentVelocity.y);

        playerDetected = type.IsDetectingPlayer();
        if (playerDetected) {
            Debug.Log("Player Detected");
        }

        if (timeLeftInMove < 0.05f) {
            isMovingDone = true;
        }
    }

    public override void OnExit(Hammond type) { }
}