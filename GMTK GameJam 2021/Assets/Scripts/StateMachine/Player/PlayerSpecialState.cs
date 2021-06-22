using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State/SpecialState")]
public class PlayerSpecialState : State<Player> {
    
    public override void OnEnter(Player player) {
        
    }

    public override void LogicUpdate(Player player) {
        if (player.velocity.y < 0f && player.activeController == Player.AnimationControllerType.Hammond) {
            player.RB.AddForce(Vector2.down*2.5f, ForceMode2D.Impulse);
        }
    }

    public override void OnExit(Player player) {
    }
}