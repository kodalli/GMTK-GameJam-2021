using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/AnimationFinishedDecision")]
public class CheckAnimationFinishedDecision : Decision<Player> {
    [SerializeField] private PlayerData playerData;
    public override bool Decide(Player type) => playerData.IsAnimationFinished;
}