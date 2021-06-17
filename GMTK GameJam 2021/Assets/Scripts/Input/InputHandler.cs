using UnityEngine;

public class InputHandler : MonoBehaviour {

    [SerializeField] private InputReader inputReader = default;
    
    [Space]
    [SerializeField] private PlayerInputData playerInputData = default;

    [SerializeField] private InteractionInputData interactionInputData = default;
    
    private void Awake() {
        inputReader = Resources.Load<InputReader>("Input/InputReader");
        playerInputData = Resources.Load<PlayerInputData>("Input/PlayerInputData");
        interactionInputData = Resources.Load<InteractionInputData>("Input/InteractionInputData");
    }

    private void OnEnable() {
        inputReader.EnableGameplayInput();
        playerInputData.RegisterEvents();
        interactionInputData.RegisterEvents();
    }
    private void OnDisable() {
        playerInputData.UnregisterEvents();
        interactionInputData.UnregisterEvents();
    }

    private void Start() {
        playerInputData.Reset();
        interactionInputData.Reset();
    }
}   