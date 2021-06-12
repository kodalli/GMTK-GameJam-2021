using System;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Dridd Base State")]
public class DriddBaseState : BaseState<Dridd, DriddBaseState> {
    
    public static event Action<DriddBaseState> OnStateTransition;

    public DriddBaseState(string stateName, State<Dridd>[] states, Transition<Dridd, DriddBaseState>[] transitions,
        Action<Dridd> enterStateEvent, Action<Dridd> exitStateEvent, Action<Dridd> updateStateEvent) : base(stateName, states, transitions, enterStateEvent, exitStateEvent,
        updateStateEvent) {
    }
    protected override void CheckTransitions(Dridd entity) {
        for (var i = 0; i < transitions.Length; i++) {
            var decisionSucceeded = transitions[i].decision.Decide(entity);
            OnStateTransition?.Invoke(decisionSucceeded ? transitions[i].trueState : transitions[i].falseState);
        }
    }

    protected override void ResetAnimationFinished(Dridd entity) => entity.IsAnimationFinished = false;
    public void AnimationFinishTrigger(Dridd entity) => entity.IsAnimationFinished = true;
}