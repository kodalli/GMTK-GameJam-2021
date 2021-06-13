using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hammond/DetectingPlayerDecision")]
public class H_CheckIfMoveDoneDecision : Decision<Hammond> {
    [SerializeField] private HammondMoveState moveState;
    public override bool Decide(Hammond type) => moveState.playerDetected;
}