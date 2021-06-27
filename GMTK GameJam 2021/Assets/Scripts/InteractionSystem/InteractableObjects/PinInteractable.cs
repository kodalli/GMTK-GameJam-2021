using UnityEngine;

public class PinInteractable : InteractableBase {
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Animator Anim;
    private bool activated;
    public override void OnInteract() {
        base.OnInteract();
        if (!activated && playerData.activeController == Player.AnimationControllerType.Hammond && playerData.velocityY < 0f) {
            activated = true;
            Anim.Play("pin_down");
        }
    }
}