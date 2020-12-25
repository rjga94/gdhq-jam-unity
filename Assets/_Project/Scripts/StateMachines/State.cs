using System.Collections;
using StateMachines.Player;

namespace StateMachines
{
    public abstract class State
    {
        protected readonly PlayerStateMachine PlayerStateMachine;

        protected State(PlayerStateMachine playerStateMachine)
        {
            PlayerStateMachine = playerStateMachine;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Update()
        {
            yield break;
        }
        
        public virtual IEnumerator FixedUpdate()
        {
            yield break;
        }
    }
}