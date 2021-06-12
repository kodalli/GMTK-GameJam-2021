using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/GroundedDecision")]
public class CheckGroundedDecision : Decision<Player> {
    public override bool Decide(Player player) => player.IsGrounded;
}