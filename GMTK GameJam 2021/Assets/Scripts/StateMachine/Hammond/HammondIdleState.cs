using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State/Hammond/IdleState")]
public class HammondIdleState : State<Hammond> {
    
    private float timeTillIdleEnd;
    public bool isIdleDone;
    public override void OnEnter(Hammond type) {
        timeTillIdleEnd = 2f;
        isIdleDone = false;
        type.rb.velocity = Vector2.zero;
        type.Flip();
    }

    public override void LogicUpdate(Hammond type) {
        type.anim.Play("hammond_idle");

        timeTillIdleEnd -= Time.deltaTime;
        
        if (timeTillIdleEnd < 0.05f) {
            isIdleDone = true;
        }
    }

    public override void OnExit(Hammond type) {
    }
}