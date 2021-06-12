using UnityEngine;

public class Hammond : MonoBehaviour {
    
    [Header("State Machine")]
    [SerializeField] private DriddBaseState currentState;
    [SerializeField] private DriddBaseState remainState;
    
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
}