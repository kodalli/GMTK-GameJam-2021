using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player Data")]
public class PlayerData : ScriptableObject {
    
    [Header("Base Player Info")] 
    public float maxHealth;
    public float currentHealth = 50;
    public float currentScore = 100;

    [Header("Animation")] 
    public bool isAnimationFinished;

    [Header("Move State Settings")] 
    public float movementSpeed = 7f;
    public float jumpSpeed = 40f;
    public int facingDirection;
    
    public void Reset() {
        isAnimationFinished = false;
        facingDirection = 1;
    }
}