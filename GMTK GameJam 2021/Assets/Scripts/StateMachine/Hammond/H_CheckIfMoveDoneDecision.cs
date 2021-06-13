using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hammond/MoveDoneDecision")]
public class H_CheckIfMoveDoneDecision : Decision<Hammond> {
    [SerializeField] private HammondMoveState moveState;
    public override bool Decide(Hammond type) => moveState.isMovingDone;
}