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
            inputHandler = actor.inputHandler;
            if(actor == null)
            {
                Debug.LogError("ActorBehaviour requires an Actor component in its hierarchy.", this);
                return;
            }
            OnActorAwake();
        }

        // Override this method in derived classes for custom Awake behaviour
        protected virtual void OnActorAwake() { }
    }
}