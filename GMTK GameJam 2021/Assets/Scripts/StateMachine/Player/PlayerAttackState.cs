using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/State/AttackState")]
public class PlayerAttackState : State<Player> {

    [SerializeField] private PlayerInputData playerInputData;
    [SerializeField] private PlayerData playerData;

    public override void OnEnter(Player type) {
    }

    public override void LogicUpdate(Player type) {
        
    }

    public override void OnExit(Player type) {
    }
}