using UnityEngine;

namespace NeatWolf.FPS
{
    public abstract class ActorInputHandler : ActorBehaviour
    {
        protected Vector2 move;
        protected Vector2 look;

        public Vector2 GetMove() => move;
        public Vector2 GetLook() => look;
    }
}