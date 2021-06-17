using UnityEngine;

public class CrateInteractable : InteractableBase {
    [SerializeField] private PlayerData playerData;
    public override void OnInteract() {
        base.OnInteract();
        if (playerData.activeController == "dridd override")
            Destroy(gameObject);
    }
}