using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractable : InteractableBase
{
    [SerializeField] private PlayerData playerData;

    public override void OnInteract()
    {
        base.OnInteract();
        if (playerData.activeController == Player.AnimationControllerType.Default)
        {
            Debug.Log("door");
        }
    }
}
