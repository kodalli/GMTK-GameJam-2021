using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IStateMachine<in T> {
    public void OnStateEnter(T entity);
    public void OnStateUpdate(T entity);
    public void OnStateExit(T entity);
}

public abstract class BaseState<T, U> : ScriptableObject, IStateMachine<T> {
    // U is BaseState_SO
    [SerializeField] public Optional<string> stateName;
    [SerializeField] protected State<T>[] states;
    [SerializeField] protected Transition<T, U>[] transitions;

    protected event Action<T> EnterStateEvent;
    protected event Action<T> ExitStateEvent;
    protected event Action<T> UpdateStateEvent;

    protected BaseState(string stateName, State<T>[] states, Transition<T, U>[] transitions, Action<T> enterStateEvent,
        Action<T> exitStateEvent, Action<T> updateStateEvent) {
        this.stateName.Value = stateName;
        this.states = states;
        this.transitions = transitions;
        this.EnterStateEvent = enterStateEvent;
        this.ExitStateEvent = exitStateEvent;
        this.UpdateStateEvent = updateStateEvent;
    }

    protected virtual void OnEnable() {
        foreach (var state in states) {
            EnterStateEvent += state.OnEnter;
            UpdateStateEvent += state.LogicUpdate;
            ExitStateEvent += state.OnExit;
        }

        UpdateStateEvent += CheckTransitions;
        ExitStateEvent += ResetAnimationFinished;
    }

    protected virtual void OnDisable() {
        foreach (var state in states) {
            EnterStateEvent -= state.OnEnter;
            UpdateStateEvent -= state.LogicUpdate;
            ExitStateEvent -= state.OnExit;
        }

        UpdateStateEvent -= CheckTransitions;
        ExitStateEvent -= ResetAnimationFinished;
    }

    protected abstract void CheckTransitions(T entity);
    protected abstract void ResetAnimationFinished(T entity);

    public void OnStateEnter(T entity) {
        EnterStateEvent?.Invoke(entity);
    }

    public void OnStateUpdate(T entity) {
        UpdateStateEvent?.Invoke(entity);
    }

    public void OnStateExit(T entity) {
        ExitStateEvent?.Invoke(entity);
    }
}