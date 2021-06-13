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
           type.Anim.Play("hammond_run");
           type.RB.velocity = new Vector2(type.movementSpeed * type.FacingDirection, type.CurrentVelocity.y);

           playerDetected = type.IsDetectingPlayer();
           if (playerDetected) {
               type.RB.velocity = new Vector2(type.movementSpeed * 2 * type.FacingDirection, type.CurrentVelocity.y);
           }

           timeLeftInMove -= Time.deltaTime;

           if (timeLeftInMove < 0.05f) {
               isMovingDone = true;
           }
        }

        public override void OnExit(Hammond type) {
        }
    }