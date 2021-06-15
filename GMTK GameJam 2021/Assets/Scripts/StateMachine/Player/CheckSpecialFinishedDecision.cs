using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/SpecialFinishedDecision")]
public class CheckSpecialFinishedDecision : Decision<Player> {
    [SerializeField] private PlayerData playerData;
    public override bool Decide(Player type) => playerData.IsAnimationFinished;

}
