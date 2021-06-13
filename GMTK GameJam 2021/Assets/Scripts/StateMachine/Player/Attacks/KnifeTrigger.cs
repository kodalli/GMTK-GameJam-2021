using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTrigger : MonoBehaviour {
    [SerializeField] private PlayerData playerData;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other == null)
            return;
        var racIndex = other.gameObject.GetComponent<IDamageable>()?.TakeDamage(playerData.attackDamage) ?? -1;
        if (racIndex > 0) {
            var player = GetComponentInParent<Player>();
            player.ChangeAnimationController(racIndex);
        } 
    }
}
