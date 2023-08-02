// ActorBehaviour.cs
using UnityEngine;

namespace NeatWolf.FPS
{
    public abstract class ActorBehaviour : MonoBehaviour
    {
        protected Actor actor;
        protected ActorInputHandler inputHandler;

        private void Awake()
        {
            actor = GetComponentInParent<Actor>();
            if(actor == null)
            {
                Debug.LogError("ActorBehaviour requires an Actor component in its hierarchy.", this);
                return;
            }
            inputHandler = actor.inputHandler;
            OnActorAwake();
        }

        // Override this method in derived classes for custom Awake behaviour
        protected virtual void OnActorAwake() { }
    }
}