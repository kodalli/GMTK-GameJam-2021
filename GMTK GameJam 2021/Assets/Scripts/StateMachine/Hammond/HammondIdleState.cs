using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State/Hammond/IdleState")]
public class HammondIdleState : State<Hammond> {
    public override void OnEnter(Hammond type) {
    }

    public override void LogicUpdate(Hammond type) {
        type.Anim.Play("hammond_idle");
    }

    public override void OnExit(Hammond type) {
    }
}