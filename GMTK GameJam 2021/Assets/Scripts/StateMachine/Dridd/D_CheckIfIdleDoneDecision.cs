using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Dridd/isIdleDoneDecision")]
public class D_CheckIfIdleDoneDecision : Decision<Dridd> {
    [SerializeField] private DriddIdleState idleState;
    public override bool Decide(Dridd type) {
        return idleState.isIdleDone;
    }
}