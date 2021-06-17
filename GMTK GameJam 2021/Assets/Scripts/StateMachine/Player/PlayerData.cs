using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player Data")]
public class PlayerData : ScriptableObject {
    [Header("Base Player Info")] public float maxHealth;
    public float currentHealth = 50;
    public float currentScore = 100;

    [Header("Animation")]
    [SerializeField] private bool isAnimationFinished;
    public bool IsAnimationFinished { get => isAnimationFinished; set => isAnimationFinished = value; }
    public string activeController;

    [Header("Move State Settings")] 
    public float movementSpeed = 7f;
    public float jumpSpeed = 40f;
    public int facingDirection;
    public float attackDamage = 25f;

    public bool damaged;
    public float rayDistance = 4f;
    public LayerMask interactableLayer;

    public void Reset() {
        damaged = false;
        isAnimationFinished = false;
        currentHealth = 50;
        facingDirection = 1;
        activeController = default;
    }
}