using System;
using UnityEngine;

public class HammondBaseState : BaseState<Hammond, HammondBaseState> {
    public HammondBaseState(string stateName, State<Hammond>[] states, Transition<Hammond, HammondBaseState>[] transitions, Action<Hammond> enterStateEvent, Action<Hammond> exitStateEvent, Action<Hammond> updateStateEvent) : base(stateName, states, transitions, enterStateEvent, exitStateEvent, updateStateEvent) { }
    protected override void CheckTransitions(Hammond entity) {
        throw new NotImplementedException();
    }

    protected override void ResetAnimationFinished(Hammond entity) {
        throw new NotImplementedException();
    }
}


