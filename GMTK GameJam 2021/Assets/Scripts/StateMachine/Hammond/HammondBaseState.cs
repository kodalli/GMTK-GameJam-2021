using System;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Hammond Base State")]
public class HammondBaseState : BaseState<Hammond, HammondBaseState> {
    public static event Action<HammondBaseState> OnStateTransition;
    public HammondBaseState(string stateName, State<Hammond>[] states, Transition<Hammond, HammondBaseState>[] transitions, Action<Hammond> enterStateEvent, Action<Hammond> exitStateEvent, Action<Hammond> updateStateEvent) : base(stateName, states, transitions, enterStateEvent, exitStateEvent, updateStateEvent) { }
    protected override void CheckTransitions(Hammond entity) {
        for (var i = 0; i < transitions.Length; i++) {
            var decisionSucceeded = transitions[i].decision.Decide(entity);
            OnStateTransition?.Invoke(decisionSucceeded ? transitions[i].trueState : transitions[i].falseState);
        }
    }
    protected override void ResetAnimationFinished(Hammond entity) => entity.isAnimationFinished = false;
    public void AnimationFinishTrigger(Hammond entity) => entity.isAnimationFinished = true;
}


