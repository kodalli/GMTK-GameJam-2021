using UnityEngine;

public class Hammond : MonoBehaviour, IDamageable {
    [Header("State Machine")] [SerializeField]
    private HammondBaseState currentState;

    [SerializeField] private HammondBaseState remainState;
    
    [Header("Components")]
    public Animator anim; 
    public Rigidbody2D rb; 
    public SpriteRenderer sr; 
    public new BoxCollider2D collider;

    [HideInInspector] public int facingDirection;
    [HideInInspector] public Vector2 currentVelocity;
    [HideInInspector] public bool isAnimationFinished;
    
    [Header("Enemy Info")]
    public float movementSpeed;
    public float rayDistance;
    public LayerMask playerLayer;
    
    private void Awake() {
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
        currentVelocity = rb.velocity;
    }

    private void TransitionToState(HammondBaseState nextState) {
        if (nextState == remainState)
            return;

        currentState.OnStateExit(this);
        currentState = nextState;
        currentState.OnStateEnter(this);
    }

    public void AnimationFinishTrigger() => currentState.AnimationFinishTrigger(this); // Used as an Animation Event

    public bool IsDetectingPlayer() => Physics2D.Raycast(collider.bounds.center, Vector2.right * facingDirection, rayDistance, playerLayer);
    public void Flip() {
        facingDirection *= -1;
        transform.Rotate(0f, -180f, 0f);
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
    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        
        var bounds = collider.bounds;
        Gizmos.DrawWireSphere(bounds.center, 0.5f);
        Gizmos.DrawLine(bounds.center, bounds.center + (Vector3)(Vector2.right * facingDirection * rayDistance));
    }
}