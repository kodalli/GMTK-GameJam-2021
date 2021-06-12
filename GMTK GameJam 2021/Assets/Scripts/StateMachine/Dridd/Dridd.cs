using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class Dridd : MonoBehaviour {
    
    [Header("State Machine")]
    [SerializeField] private DriddBaseState currentState;
    [SerializeField] private DriddBaseState remainState;

    public Animator Anim;
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    
    private int facingDirection;
    public int FacingDirection => facingDirection;
    
    public Vector2 currentVelocity;
    public bool isAnimationFinished;

    [Space]
    public BoxCollider2D Collider;

    [Space] 
    public float movementSpeed;
    public float rayDistance = 1f;
    public float wallCheckDistance = .7f;
    
    [Space]
    public LayerMask playerLayer;
    public LayerMask wallLayer;

    private void Awake() {
        facingDirection = -1;
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
        currentVelocity = RB.velocity;
    }

    private void TransitionToState(DriddBaseState nextState) {
        if (nextState == remainState)
            return;

        currentState.OnStateExit(this);
        currentState = nextState;
        currentState.OnStateEnter(this);
    }
    
    public bool IsDetectingPlayer() => Physics2D.Raycast(Collider.bounds.center, transform.right * facingDirection, rayDistance, playerLayer);
    public void AnimationFinishTrigger() => currentState.AnimationFinishTrigger(this); // Used as an Animation Event

    public void Flip() {
        facingDirection *= -1;
        transform.Rotate(0f, -180f, 0f);
    }
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        
        var bounds = Collider.bounds;
        Gizmos.DrawWireSphere(bounds.center, 0.5f);
        Gizmos.DrawLine(bounds.center, bounds.center + (Vector3)(Vector2.right * facingDirection * rayDistance));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(bounds.center, bounds.center + (Vector3)(Vector2.right * facingDirection * wallCheckDistance));
    }
}