using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player Data")]
public class PlayerData : ScriptableObject {
    [Header("Base Player Info")] public float maxHealth;
    public float currentHealth = 50;
    public float currentScore = 100;

    [Header("Animation")]
    [SerializeField] private bool isAnimationFinished;
    public bool IsAnimationFinished { get => isAnimationFinished; set => isAnimationFinished = value; }

    [Header("Move State Settings")] 
    public float movementSpeed = 7f;
    public float jumpSpeed = 40f;
    public int facingDirection;
    public float attackDamage = 25f;

    public void Reset() {
        facingDirection = 1;
    }
}