using UnityEngine;

public class InputHandler : MonoBehaviour {

    [SerializeField] private InputReader inputReader = default;
    
    [Space]
    [SerializeField] private PlayerInputData playerInputData = default;
    
    private void Awake() {
        inputReader = Resources.Load<InputReader>("Input/InputReader");
        playerInputData = Resources.Load<PlayerInputData>("Input/PlayerInputData");
    }

    private void OnEnable() {
        inputReader.EnableGameplayInput();
        playerInputData.RegisterEvents();
    }
    private void OnDisable() {
        playerInputData.UnregisterEvents();
    }

    private void Start() {
        playerInputData.Reset();
    }
}   