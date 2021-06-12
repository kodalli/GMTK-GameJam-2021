using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions {
    // Gameplay
    public event UnityAction<Vector2> MoveEvent;
    public event UnityAction JumpEvent;
    public event UnityAction JumpCanceledEvent;

    public event UnityAction AbilityStartedEvent;
    public event UnityAction AbilityCancelledEvent;

    public event UnityAction AttackStarted;

    public event UnityAction AttackCancelled;
    public event UnityAction OpenMenuWindow;

    private GameInput GameInput { get; set; }

    private void OnEnable() {
        if (GameInput == null) {
            GameInput = new GameInput();
            GameInput.Gameplay.SetCallbacks(this);
        }

        EnableGameplayInput();
    }

    private void OnDisable() => DisableAllInput();

    #region Gameplay Actions

    public void OnMove(InputAction.CallbackContext context) {
        MoveEvent?.Invoke(context.ReadValue<Vector2>().normalized);
    }

    public void OnAbility(InputAction.CallbackContext context) {
        if (AbilityStartedEvent != null && context.phase == InputActionPhase.Started)
            AbilityStartedEvent.Invoke();

        if (AbilityCancelledEvent != null && context.phase == InputActionPhase.Canceled)
            AbilityCancelledEvent.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (JumpEvent != null && context.phase == InputActionPhase.Performed)
            JumpEvent.Invoke();

        if (JumpCanceledEvent != null && context.phase == InputActionPhase.Canceled)
            JumpCanceledEvent.Invoke();
    }

    public void OnMenu(InputAction.CallbackContext context) {
        if (OpenMenuWindow != null && context.phase == InputActionPhase.Started)
            OpenMenuWindow?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context) {
        if (AttackStarted != null && context.phase == InputActionPhase.Started)
            AttackStarted.Invoke();

        if (AttackCancelled != null && context.phase == InputActionPhase.Canceled)
            AttackCancelled.Invoke();
    }

    #endregion

    public void EnableGameplayInput() {
        GameInput.Gameplay.Enable();
        Helper.CustomLog("Gameplay Input Enabled", LogColor.White);
    }

    public void DisableAllInput() {
        GameInput.Gameplay.Disable();
        Helper.CustomLog("All Input disabled", LogColor.None);
    }
}