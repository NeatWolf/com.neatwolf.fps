using UnityEngine;

namespace NeatWolf.FPS
{
    [CreateAssetMenu(fileName = "ActorProperties", menuName = "Actor/Properties", order = 0)]
    public class ActorProperties : ScriptableObject
    {
        [Tooltip("The base movement speed of the actor.")]
        public float baseMovementSpeed = 2f;

        [Tooltip("The influence of gravity on the actor.")]
        public float gravityInfluence = 1f;

        [Tooltip("The acceleration curve for the actor's movement.")]
        public AnimationCurve movementAccelerationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        [Tooltip("The time it takes for the actor to reach maximum acceleration.")]
        public float movementAccelerationTime = 0.1f;
    }
}
