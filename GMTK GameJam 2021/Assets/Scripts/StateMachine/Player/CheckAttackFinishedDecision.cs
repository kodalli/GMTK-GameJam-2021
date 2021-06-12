using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/AttackFinishedDecision")]
public class CheckAttackFinishedDecision : Decision<Player> {
    [SerializeField] private PlayerData playerData;
    public override bool Decide(Player type) => playerData.isAnimationFinished;

}