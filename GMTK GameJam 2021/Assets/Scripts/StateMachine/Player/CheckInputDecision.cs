using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/MovingDecision")]
public class CheckInputDecision : Decision<Player> {
    
    [SerializeField] private PlayerInputData playerInputData;
    
    public override bool Decide(Player player) 
        => playerInputData.MovementInput.x != 0 && playerInputData.MovementInput.y == 0;
}