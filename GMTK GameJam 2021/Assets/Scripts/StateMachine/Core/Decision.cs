using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision<T> : ScriptableObject {
    public abstract bool Decide(T type);
}