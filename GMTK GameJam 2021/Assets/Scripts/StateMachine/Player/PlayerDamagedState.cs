using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State/DamagedState")]
public class PlayerDamagedState : State<Player> {
    [SerializeField] private PlayerData playerData;
    public override void OnEnter(Player type) {
    }

    public override void LogicUpdate(Player type) {
    }

    public override void OnExit(Player type) {
        type.RB.velocity = Vector2.zero;
        playerData.damaged = false;
    }
    
}