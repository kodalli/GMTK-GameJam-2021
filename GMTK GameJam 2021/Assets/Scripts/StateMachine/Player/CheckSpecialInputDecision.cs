using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/SpecialDecision")]
public class CheckSpecialInputDecision : Decision<Player> {
    [SerializeField] private PlayerInputData playerInputData;
    public override bool Decide(Player type) => playerInputData.SpecialPressed;
}