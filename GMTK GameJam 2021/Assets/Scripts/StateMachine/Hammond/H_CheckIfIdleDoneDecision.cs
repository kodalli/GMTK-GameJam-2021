using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hammond/isIdleDoneDecision")]
public class H_CheckIfIdleDoneDecision : Decision<Hammond> {
    [SerializeField] private HammondIdleState idleState;

    public override bool Decide(Hammond type) {
        return idleState.isIdleDone;
    }
}