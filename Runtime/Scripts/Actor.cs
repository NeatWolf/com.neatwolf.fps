// Actor.cs
using UnityEngine;

namespace NeatWolf.FPS
{
    public class Actor : MonoBehaviour
    {
        [SerializeField]
        public ActorProperties properties;

        [SerializeField]
        public ActorInputHandler inputHandler;
    }
}