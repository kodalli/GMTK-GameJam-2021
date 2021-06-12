using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/State/Dridd/IdleState")]
public class DriddIdleState : State<Dridd> {
    
    public override void OnEnter(Dridd type) {
    }

    public override void LogicUpdate(Dridd type) {
        type.Anim.Play("dridd_idle");
    }

    public override void OnExit(Dridd type) {
    }
}