using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : PlayerPhysics {
    
    [Header("State Machine")] 
    public PlayerBaseState currentBaseState;
    public PlayerBaseState remainBaseState;

    [Header("Data")] 
    [SerializeField] private PlayerData playerData;

    private void Awake() {
        currentBaseState.Refresh();
    }

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

    public void AnimationFinishTrigger() => currentBaseState.AnimationFinishTrigger(); // Used as an Animation Event
    public void TakeDamage(Dridd enemy, float damage) {
        playerData.currentHealth -= damage;
        
        RB.velocity = Vector2.zero;
        if (enemy.transform.position.x > transform.position.x) {
            RB.AddForce(new Vector2(-25f,20f), ForceMode2D.Impulse);
            playerData.damaged = true;
        }
        else {
            RB.AddForce(new Vector2(25f, 20f), ForceMode2D.Impulse);
            playerData.damaged = true;
        }

        Debug.Log(playerData.currentHealth);
        
        if (playerData.currentHealth <= 0) {
            Helper.CustomLog("GAME OVER", LogColor.White);
        }
    }
    
}