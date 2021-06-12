using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/AttackDecision")]
public class CheckAttackInputDecision : Decision<Player> {
    [SerializeField] private PlayerInputData playerInputData;
    public override bool Decide(Player type) => playerInputData.AttackPressed;
}