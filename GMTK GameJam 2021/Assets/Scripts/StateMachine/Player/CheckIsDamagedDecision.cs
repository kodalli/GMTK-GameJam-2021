using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsDamagedDecision")]
public class CheckIsDamagedDecision : Decision<Player> {
    [SerializeField] private PlayerData playerData;
    public override bool Decide(Player type) => playerData.damaged;
}