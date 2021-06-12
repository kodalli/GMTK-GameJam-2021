using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dridd : MonoBehaviour {
    
    [Header("State Machine")]
    [SerializeField] private DriddBaseState currentState;
    [SerializeField] private DriddBaseState remainState;
    
    public Animator Anim { get; set; }
    public Rigidbody2D RB { get; set; }
    public SpriteRenderer SR { get; set; }
    public BoxCollider2D Collider { get; set; }

    public int FacingDirection { get; set; }
    public Vector2 CurrentVelocity { get; set; }
    public bool IsAnimationFinished { get; set; }
    
    private void Awake() {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        Collider = GetComponent<BoxCollider2D>();

        FacingDirection = 1;
    }
    private void OnEnable() {
        DriddBaseState.OnStateTransition += TransitionToState;
    }
    
    private void OnDisable() {
        DriddBaseState.OnStateTransition -= TransitionToState;
    }

    private void Start() {
        currentState.OnStateEnter(this);
    }
    private void FixedUpdate() {
        currentState.OnStateUpdate(this);
        CurrentVelocity = RB.velocity;
    }

    private void TransitionToState(DriddBaseState nextState) {
        if (nextState == remainState)
            return;

        currentState.OnStateExit(this);
        currentState = nextState;
        currentState.OnStateEnter(this);
    }
    
    
    public void AnimationFinishTrigger() => currentState.AnimationFinishTrigger(this); // Used as an Animation Event
}