using System.Collections;
using UnityEngine;

public class CrateInteractable : InteractableBase {
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ParticleSystem ps;
    public override void OnInteract() {
        base.OnInteract();
        if (playerData.activeController == Player.AnimationControllerType.Dridd)
        {
            ps.Play();
            StartCoroutine(Shrink());
        }
        
    }

    private IEnumerator Shrink()
    {
        var count = 1f;
        while (count > 0f)
        {
            count -= 0.01f;
            transform.localScale = transform.localScale * (count); 
            yield return default;
        }
        Destroy(gameObject, 0.5f);
    }
}