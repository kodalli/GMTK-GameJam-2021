using UnityEngine;

public class Hammond : MonoBehaviour, IDamageable {
    [Header("State Machine")] [SerializeField]
    private HammondBaseState currentState;

    [SerializeField] private HammondBaseState remainState;

    [Space] public Animator Anim;
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    public BoxCollider2D Collider;

    private int facingDirection;
    public int FacingDirection => facingDirection;
    public Vector2 CurrentVelocity;
    public bool IsAnimationFinished;

    [Space] public float movementSpeed;
    public float rayDistance = 1f;
    public float wallCheckDistance = .7f;
    public float health = 100f;

    [Space] public LayerMask playerLayer;

    private void Awake() {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        Collider = GetComponent<BoxCollider2D>();

        facingDirection = -1;
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

    public bool IsDetectingPlayer() => Physics2D.Raycast(Collider.bounds.center, Vector2.right * facingDirection,
        rayDistance, playerLayer);

    public void AnimationFinishTrigger() => currentState.AnimationFinishTrigger(this); // Used as an Animation Event

    public void Flip() {
        facingDirection *= -1;
        transform.Rotate(0f, -180f, 0f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.black;

        var bounds = Collider.bounds;
        Gizmos.DrawWireSphere(bounds.center, 0.5f);
        Gizmos.DrawLine(bounds.center, bounds.center + (Vector3) (Vector2.right * facingDirection * rayDistance));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(bounds.center, bounds.center + (Vector3) (Vector2.right * facingDirection * wallCheckDistance));
    }

    public int TakeDamage(float damage) {
        if (health > 0f) {
            health -= damage;
            // isTakingDamage = true;
            Debug.Log("current health: " + health);
            return -1;
        }
        else {
            Destroy(gameObject, 0.1f);
            return 2; // hammond is 2 index for animation override controller in Player class
        }
    }
}