using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Dridd/DetectingPlayerDecision")]
public class D_CheckIfDetectingPlayerDecision : Decision<Dridd> {
    [SerializeField] private DriddMoveState moveState;

    public override bool Decide(Dridd type) => moveState.playerDetected;
}