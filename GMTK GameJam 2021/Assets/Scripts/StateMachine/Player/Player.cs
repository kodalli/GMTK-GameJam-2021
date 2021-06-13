using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : PlayerPhysics {
    
    [Header("State Machine")] 
    public PlayerBaseState currentBaseState;
    public PlayerBaseState remainBaseState;
    // 0,1,2,3 -> base, dridd, hammond, poof
    public RuntimeAnimatorController[] animationControllers;

    protected override void OnEnable() {
        base.OnEnable();
        PlayerBaseState.OnStateTransition += TransitionToState;
    }
    
    protected override void OnDisable() {
        base.OnDisable();
        PlayerBaseState.OnStateTransition -= TransitionToState;
    }

    protected override void Start() {
        base.Start();
        currentBaseState.Refresh();
        currentBaseState.OnStateEnter(this);
    }

    protected override void Update() {
        base.Update();
        currentBaseState.OnStateUpdate(this);
    }

    private void TransitionToState(PlayerBaseState nextBaseState) {
        if (nextBaseState == remainBaseState)
            return;

        currentBaseState.OnStateExit(this);
        Anim.SetBool(currentBaseState.animBoolName.Value, false);
        currentBaseState = nextBaseState;
        Anim.SetBool(currentBaseState.animBoolName.Value, true);
        currentBaseState.OnStateEnter(this);
    }

    public void ChangeAnimationController(int index) {
        if (index < 0 || index > animationControllers.Length - 1)
            return;
        Anim.runtimeAnimatorController = animationControllers[index];
    }

    public void AnimationFinishTrigger() => currentBaseState.AnimationFinishTrigger(); // Used as an Animation Event
}