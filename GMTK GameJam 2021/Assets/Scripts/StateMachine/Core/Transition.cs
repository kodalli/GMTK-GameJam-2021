using UnityEngine.Events;

[System.Serializable]
public struct Transition<T, U> {
    public Decision<T> decision;
    public U trueState;
    public U falseState;
}