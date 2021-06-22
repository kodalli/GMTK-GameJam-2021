using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTrigger : MonoBehaviour {
    [SerializeField] private PlayerData playerData;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other == null) return;
        var animControllerToChangeTo = other.gameObject.GetComponent<IDamageable>()?.TakeDamage(playerData.attackDamage) ?? Player.AnimationControllerType.Default;
        // Beware if some damageable causes the player to switch from another animation controller back to default this won't work 
        if (animControllerToChangeTo == Player.AnimationControllerType.Default) return;
        var player = GetComponentInParent<Player>();
        player.ChangeAnimationController(animControllerToChangeTo);
    }
}
