using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Dridd/isMoveDoneDecision")]
public class D_CheckIfMoveDoneDecision : Decision<Dridd> {
    [SerializeField] private DriddMoveState moveState;
    public override bool Decide(Dridd type) {
        return moveState.isMovingDone;
    }
}