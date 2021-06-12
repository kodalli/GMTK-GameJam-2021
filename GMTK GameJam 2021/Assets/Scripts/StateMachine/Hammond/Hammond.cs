using UnityEngine;

public class Hammond : MonoBehaviour {
    
    [Header("State Machine")]
    [SerializeField] private HammondBaseState currentState;
    [SerializeField] private HammondBaseState remainState;
    
    public Animator Anim { get; set; }
    public Rigidbody2D RB { get; set; }
    public SpriteRenderer SR { get; set; }
    public BoxCollider2D Collider { get; set; }

    public int FacingDirection { get; set; }
    public Vector2 CurrentVelocity { get; set; }
    public bool IsAnimationFinished { get; set; }
    
    private void Awake() {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        Collider = GetComponent<BoxCollider2D>();

        FacingDirection = 1;
    }
    private void OnEnable() {
        HammondBaseState.OnStateTransition += TransitionToState;
    }
    
    private void OnDisable() {
        HammondBaseState.OnStateTransition -= TransitionToState;
    }

    private void Start() {
        currentState.OnStateEnter(this);
    }
    private void FixedUpdate() {
        currentState.OnStateUpdate(this);
        CurrentVelocity = RB.velocity;
    }

    private void TransitionToState(HammondBaseState nextState) {
        if (nextState == remainState)
            return;

        currentState.OnStateExit(this);
        currentState = nextState;
        currentState.OnStateEnter(this);
    }
}