using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputData", menuName = "Input/PlayerInputData")]
public class PlayerInputData : ScriptableObject {
    [SerializeField] private InputReader inputReader = null;

    [Header("Game Input"), Space] [SerializeField]
    private Vector2 movementInput;

    [SerializeField] private bool jumpInput;
    [SerializeField] private bool abilityPressed;
    [SerializeField] private bool abilityReleased;
    [SerializeField] private bool attackPressed;
    [SerializeField] private bool attackReleased;
    [SerializeField] private bool specialPressed;
    [SerializeField] private bool specialReleased;

    // Properties
    public Vector2 MovementInput {
        get => movementInput;
        set => movementInput = value;
    }

    public bool JumpInput {
        get => jumpInput;
        set => jumpInput = value;
    }

    public bool AbilityPressed {
        get => abilityPressed;
        set => abilityPressed = value;
    }

    public bool AbilityReleased {
        get => abilityReleased;
        set => abilityReleased = value;
    }

    public bool AttackPressed {
        get => attackPressed;
        set => attackPressed = value;
    }

    public bool AttackReleased {
        get => attackReleased;
        set => attackReleased = value;
    }

    public bool SpecialPressed {
        get => specialPressed;
        set => specialPressed = value;
    }

    public bool SpecialReleased {
        get => specialReleased;
        set => specialReleased = value;
    }


    public void RegisterEvents() {
        inputReader.MoveEvent += OnMove;
        inputReader.JumpEvent += OnJumpInitiated;
        inputReader.JumpCanceledEvent += OnJumpCanceled;
        inputReader.AbilityStartedEvent += OnAbilityPressed;
        inputReader.AbilityCancelledEvent += OnAbilityReleased;
        inputReader.AttackStartedEvent += OnAttackPressed;
        inputReader.AttackCancelledEvent += OnAttackReleased;
        inputReader.SpecialStartedEvent += OnSpecialPressed;
        inputReader.SpecialCancelledEvent += OnSpecialReleased;
        Helper.CustomLog("Player: Input Events Registered", LogColor.Green);
    }

    public void UnregisterEvents() {
        inputReader.MoveEvent -= OnMove;
        inputReader.JumpEvent -= OnJumpInitiated;
        inputReader.JumpCanceledEvent -= OnJumpCanceled;
        inputReader.AbilityStartedEvent -= OnAbilityPressed;
        inputReader.AbilityCancelledEvent -= OnAbilityReleased;
        inputReader.AttackStartedEvent -= OnAttackPressed;
        inputReader.AttackCancelledEvent -= OnAttackReleased;
        inputReader.SpecialStartedEvent -= OnSpecialPressed;
        inputReader.SpecialCancelledEvent -= OnSpecialReleased;
        Helper.CustomLog("Player: Input Events Unregistered", LogColor.Green);
    }


    private void OnMove(Vector2 input) => MovementInput = input;
    private void OnJumpInitiated() => JumpInput = true;
    private void OnJumpCanceled() => JumpInput = false;

    private void OnAbilityPressed() {
        abilityPressed = true;
        abilityReleased = false;
    }

    private void OnAbilityReleased() {
        abilityPressed = false;
        abilityReleased = true;
    }

    private void OnAttackPressed() {
        attackPressed = true;
        attackReleased = false;
    }

    private void OnAttackReleased() {
        attackPressed = false;
        attackReleased = true;
    }

    private void OnSpecialPressed() {
        specialPressed = true;
        specialReleased = false;
    }

    private void OnSpecialReleased() {
        specialPressed = false;
        specialReleased = true;
    }

    public void Reset() {
        movementInput = Vector2.zero;
        jumpInput = false;
    }
}