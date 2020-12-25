using System.Collections;
using UnityEngine;

namespace StateMachines
{
    public abstract class State<T> where T : MonoBehaviour
    {
        protected readonly T Controller;

        protected State(T controller)
        {
            Controller = controller;
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