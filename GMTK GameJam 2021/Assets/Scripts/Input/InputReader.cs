using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions {
    // Gameplay
    public event UnityAction<Vector2> MoveEvent;
    public event UnityAction JumpEvent;
    public event UnityAction JumpCanceledEvent;

    public event UnityAction AbilityStartedEvent;
    public event UnityAction AbilityCancelledEvent;

    public event UnityAction OpenMenuWindow;

    private GameInput GameInput{ get; set; }

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
        throw new System.NotImplementedException();
    }

    public void OnAbility(InputAction.CallbackContext context) {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context) {
        throw new System.NotImplementedException();
    }

    public void OnMenu(InputAction.CallbackContext context) {
        throw new System.NotImplementedException();
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