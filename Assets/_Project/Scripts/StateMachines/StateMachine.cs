using UnityEngine;

namespace StateMachines
{
    public abstract class StateMachine<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected State<T> State;
        
        public void SetState(State<T> state)
        {
            State = state;
            StartCoroutine(State.Start());
        }
    }
}