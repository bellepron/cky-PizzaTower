using UnityEngine;

namespace PizzaTower.Characters.DeliveryMan
{
    public class DeliveryManAnimator : MonoBehaviour
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public float TransitionTime { get; private set; }

        public void UpdateValues(float movementSpeed)
        {
            Animator.speed = movementSpeed;
        }
    }
}