using System;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private InputHandler inputHandler;
    private void Awake() {
        inputHandler = gameObject.AddComponent<InputHandler>();
    }
}