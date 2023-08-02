using UnityEngine;

namespace NeatWolf.FPS
{
    [CreateAssetMenu(fileName = "ActorProperties", menuName = "Actor/Properties", order = 0)]
    public class ActorProperties : ScriptableObject
    {
        public float baseMovementSpeed = 2f;
        public float gravityInfluence = 1f;
        public AnimationCurve movementAccelerationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        public float movementAccelerationTime = 0.1f;
    }
}