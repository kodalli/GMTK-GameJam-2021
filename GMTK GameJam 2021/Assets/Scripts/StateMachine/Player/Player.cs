using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : PlayerPhysics {
    [Header("State Machine")] public PlayerBaseState currentBaseState;

    public PlayerBaseState remainBaseState;

    public List<AnimController> animationControllers;

    public AnimationControllerType activeController = default;

    private readonly Dictionary<AnimationControllerType, RuntimeAnimatorController> animationsControllerDict =
        new Dictionary<AnimationControllerType, RuntimeAnimatorController>();

    [Header("Data")] [SerializeField] private PlayerData playerData;

    [Space, Header("Interaction Logic"), SerializeField]
    private InteractionLogic interactionLogic;

    public enum AnimationControllerType {
        Default,
        Dridd,
        Hammond,
        Poof,
    }

    [System.Serializable]
    public struct AnimController {
        public AnimationControllerType type;
        public RuntimeAnimatorController controller;
    }

    private void Awake() {
        currentBaseState.Refresh();

        foreach (var ac in animationControllers) {
            animationsControllerDict.Add(ac.type, ac.controller);
        }
    }

    protected override void OnEnable() {
        base.OnEnable();
        PlayerBaseState.OnStateTransition += TransitionToState;
        Anim.runtimeAnimatorController = animationsControllerDict[activeController];
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
        interactionLogic.UpdateInteractable(this, collider.bounds.center);
        playerData.activeController = activeController;
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

    public void ChangeAnimationController(AnimationControllerType type) {
        Anim.runtimeAnimatorController = animationsControllerDict[type];
        activeController = type;
    }

    public void AnimationFinishTrigger() => currentBaseState.AnimationFinishTrigger(); // Used as an Animation Event

    public void TakeDamage(Dridd enemy, float damage) {
        playerData.currentHealth -= damage;

        RB.velocity = Vector2.zero;
        if (enemy.transform.position.x > transform.position.x) {
            RB.AddForce(new Vector2(-25f, 20f), ForceMode2D.Impulse);
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