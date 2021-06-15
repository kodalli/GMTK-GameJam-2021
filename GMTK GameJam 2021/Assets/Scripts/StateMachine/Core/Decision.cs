using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision<T> : ScriptableObject {
    public string decisionName; 
    public abstract bool Decide(T type);

    public void OnEnable() {
        
    }
}