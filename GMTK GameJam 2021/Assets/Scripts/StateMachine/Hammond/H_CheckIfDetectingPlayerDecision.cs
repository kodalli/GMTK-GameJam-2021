using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hammond/DetectingPlayerDecision")]
public class H_CheckIfDetectingPlayerDecision : Decision<Hammond> {
    [SerializeField] private HammondMoveState moveState;

    public override bool Decide(Hammond type) => moveState.playerDetected;
}
