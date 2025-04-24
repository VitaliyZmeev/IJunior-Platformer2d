namespace Platformer2d
{
    public abstract class State<T> where T : Actor
    {
        protected T Actor;
        protected StateMachine<T> StateMachine;

        public State(T actor, StateMachine<T> stateMachine)
        {
            Actor = actor;
            StateMachine = stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {
        }
    }
}