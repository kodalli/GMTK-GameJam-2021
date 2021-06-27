using UnityEngine;

[CreateAssetMenu(fileName = "InteractionLogic", menuName = "InteractionSystem/InteractionLogic", order = 0)]
public class InteractionLogic : ScriptableObject {
    [SerializeField] private Optional<float> useRequiredDistance;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InteractionInputData interactionInputData;
    [SerializeField] private InteractionData interactionData;
    [SerializeField] private PlayerInputData playerInputData;

    private InteractableBase interactable;

    public void UpdateInteractable(Player player, Vector3 center) {
        CheckForInteractable(player, center);
        CheckForInteractableInput(player);
        CheckForSpecialInteraction(player);
    }

    private void CheckForInteractable(Player player, Vector3 center) {
        var hitSomething = Helper.Raycast(center,
            player.transform.right, playerData.rayDistance, playerData.interactableLayer, out var ray);
        var hitSomethingDown = Helper.Raycast(center,
            player.transform.up * -1, playerData.rayDistance, playerData.interactableLayer, out var rayDown);
        if (hitSomething) {
            interactable = ray.transform.GetComponent<InteractableBase>();
            if (interactable != null) {
                if (interactionData.IsEmpty()) {
                    interactionData.Interactable = interactable;
                }
                else {
                    if (!interactionData.IsSameInteractable(interactable)) {
                        interactionData.Interactable = interactable;
                    }
                }
            }
        }
        else if (hitSomethingDown) {
            interactable = rayDown.transform.GetComponent<InteractableBase>();
            if (interactable != null) {
                if (interactionData.IsEmpty()) {
                    interactionData.Interactable = interactable;
                }
                else {
                    if (!interactionData.IsSameInteractable(interactable)) {
                        interactionData.Interactable = interactable;
                    }
                }
            }
        }
        else {
            interactionData.ResetData();
            interactable = null;
        }

        Debug.DrawRay(center, player.transform.right * playerData.rayDistance,
            hitSomething ? Color.green : Color.red);
        Debug.DrawRay(center, player.transform.up * (-1 * playerData.rayDistance),
            hitSomethingDown ? Color.green : Color.red);
    }

    private void CheckForInteractableInput(Player player) {
        if (interactionData.IsEmpty() || !interactionInputData.isInteracting ||
            !interactionData.Interactable.IsInteractable ||
            interactionData.Interactable.IsSpecialInteraction) return;

        var distanceBetweenInteractable = interactable.transform.position.x - player.transform.position.x;
        Debug.Log(distanceBetweenInteractable);
        if (distanceBetweenInteractable >= interactable.RequiredDistance && useRequiredDistance.Enabled) return;

        if (interactionData.Interactable.HoldInteract) {
            interactionInputData.holdTimer += Time.deltaTime;
            if (!(interactionInputData.holdTimer >= interactionData.Interactable.HoldDuration)) return;
            interactionData.Interact();
            interactionInputData.isInteracting = false;
        }
        else {
            interactionData.Interact();
            // Debug.Log("called Interact()");
            interactionInputData.isInteracting = false;
        }
    }

    private void CheckForSpecialInteraction(Player player) {
        if (player.activeController == Player.AnimationControllerType.Default) return;
        if (interactionData.IsEmpty() || !playerInputData.isUsingSpecial ||
            !interactionData.Interactable.IsInteractable) return;
        if (!interactionData.Interactable.IsSpecialInteraction) return;
        // dridd
        if (interactionData.Interactable.HoldInteract) {
            playerInputData.holdTimer += Time.deltaTime;
            if (!(playerInputData.holdTimer >= interactionData.Interactable.HoldDuration)) return;
            interactionData.Interact();
            playerInputData.isUsingSpecial = false;
        }
        else {
            interactionData.Interact();
            playerInputData.isUsingSpecial = false;
        }
    }
}