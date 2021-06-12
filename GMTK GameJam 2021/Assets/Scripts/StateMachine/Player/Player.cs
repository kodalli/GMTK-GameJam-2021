using UnityEngine;

public class Player : PlayerPhysics {
    
    [Header("State Machine")] 
    public PlayerStateSO currentState;
    public PlayerStateSO remainState;

    protected override void OnEnable() {
        base.OnEnable();
        PlayerStateSO.OnStateTransition += TransitionToState;
    }
    
    protected override void OnDisable() {
        base.OnDisable();
        PlayerStateSO.OnStateTransition -= TransitionToState;
    }

    protected override void Start() {
        base.Start();
        currentState.Refresh();
        currentState.OnStateEnter(this);
    }

    protected override void Update() {
        base.Update();
        currentState.OnStateUpdate(this);
    }

    private void TransitionToState(PlayerStateSO nextState) {
        if (nextState == remainState)
            return;

        currentState.OnStateExit(this);
        if (currentState.animBoolName.Enabled) 
            Anim.SetBool(currentState.animBoolName.Value, false);
        currentState = nextState;
        if (currentState.animBoolName.Enabled) 
            Anim.SetBool(currentState.animBoolName.Value, true);
        currentState.OnStateEnter(this);
    }

    public void AnimationFinishTrigger() => currentState.AnimationFinishTrigger(); // Used as an Animation Event
}