using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/State/IdleState")]
public class PlayerIdleState : State<Player> {
    
    public override void OnEnter(Player player) {
        player.RB.velocity = Vector2.zero;
    }

    public override void LogicUpdate(Player player){

    }

    public override void OnExit(Player player){
    }

}