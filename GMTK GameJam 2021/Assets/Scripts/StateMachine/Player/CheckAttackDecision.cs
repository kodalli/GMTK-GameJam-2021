using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/AttackDecision")]
public class CheckAttackDecision : Decision<Player> {
    [SerializeField] private PlayerInputData playerInputData;
    public override bool Decide(Player type) => playerInputData.AttackStarted;
}