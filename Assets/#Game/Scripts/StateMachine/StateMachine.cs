using System;
using System.Collections.Generic;

namespace Platformer2d
{
    public abstract class StateMachine<T> where T : Actor
    {
        private readonly Dictionary<Type, State<T>> _states = new();

        private State<T> _currentState;

        public abstract void AddStates(T actor);

        public void Update()
        {
            _currentState.Update();
        }

        public void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }

        public void TransitToState(Type state)
        {
            _currentState?.Exit();
            SetState(state);
        }

        protected void AddState(State<T> state)
        {
            _states.Add(state.GetType(), state);
        }

        protected void SetState(Type state)
        {
            _currentState = _states[state];
            _currentState.Enter();
        }
    }
}