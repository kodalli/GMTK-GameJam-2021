using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerTest", menuName = "Script/GenerateScript")]
public class PlayerTest : MonoBehaviour {
    
}
public class Player : PlayerPhysics {
    [Header("State Machine")] public PlayerBaseState currentBaseState;

    public PlayerBaseState remainBaseState;

    // 0,1,2,3 -> base, dridd, hammond, poof
    public RuntimeAnimatorController[] animationControllers;
    public string ActiveController => Anim.runtimeAnimatorController.name;

    [Header("Data")] [SerializeField] private PlayerData playerData;
    private void Awake() {
        currentBaseState.Refresh();
    }

    protected override void OnEnable() {
        base.OnEnable();
        PlayerBaseState.OnStateTransition += TransitionToState;
    }

    protected override void OnDisable() {
        base.OnDisable();
        PlayerBaseState.OnStateTransition -= TransitionToState;
    }

    protected override void Start() {
        base.Start();
        currentBaseState.OnStateEnter(this);
    }
    [ContextMenu("GenerateScript")]
    public void GenerateScript() {
        // AssetDatabase.LoadAssetAtPath($"Assets/Resources/PlayerTest.cs", typeof(Player));
        Debug.Log("generating script");
        var thing = ObjectFactory.CreateInstance<Player>();
        AssetDatabase.CreateAsset(thing, "Assets/Resources/PlayerTest.cs");
        AssetDatabase.SaveAssets(); 
    }

    protected override void Update() {
        base.Update();
        currentBaseState.OnStateUpdate(this);
    }

    private void TransitionToState(PlayerBaseState nextBaseState) {
        if (nextBaseState == remainBaseState)
            return;

        currentBaseState.OnStateExit(this);
        Anim.SetBool(currentBaseState.animBoolName.Value, false);
        currentBaseState = nextBaseState;
        Anim.SetBool(currentBaseState.animBoolName.Value, true);
        currentBaseState.OnStateEnter(this);
    }

    public void ChangeAnimationController(int index) {
        if (index < 0 || index > animationControllers.Length - 1)
            return;
        Anim.runtimeAnimatorController = animationControllers[index];
    }

    public void AnimationFinishTrigger() => currentBaseState.AnimationFinishTrigger(); // Used as an Animation Event

    public void TakeDamage(Dridd enemy, float damage) {
        playerData.currentHealth -= damage;

        RB.velocity = Vector2.zero;
        if (enemy.transform.position.x > transform.position.x) {
            RB.AddForce(new Vector2(-25f, 20f), ForceMode2D.Impulse);
            playerData.damaged = true;
        }
        else {
            RB.AddForce(new Vector2(25f, 20f), ForceMode2D.Impulse);
            playerData.damaged = true;
        }

        Debug.Log(playerData.currentHealth);

        if (playerData.currentHealth <= 0) {
            Helper.CustomLog("GAME OVER", LogColor.White);
        }
    }
}