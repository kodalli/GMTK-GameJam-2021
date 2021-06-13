using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillTrigger : MonoBehaviour {
    
    public Dridd dridd;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other == null)
            return;
        other.gameObject.GetComponent<Player>()?.TakeDamage(dridd, 10);
    }
}
