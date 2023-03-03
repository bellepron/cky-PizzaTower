using PizzaTower.Helpers;
using UnityEngine;

namespace PizzaTower.Characters.Chef
{
    public class ChefAnimator : MonoBehaviour
    {
        [field: SerializeField] private Animator Animator { get; set; }
        [field: SerializeField] private float TransitionTime { get; set; }
        private float MovementSpeed { get; set; }
        private float CookSpeed { get; set; }

        public void UpdateValues(float movementSpeed, float cookSpeed)
        {
            MovementSpeed = movementSpeed;
            CookSpeed = cookSpeed;

            UpdateSpeed();
        }

        private void SetAnimatorSpeed(float value)
        {
            Animator.speed = value;
        }

        public void Cook()
        {
            Animator.CrossFade(AnimatorHelper.CHEF_COOK, TransitionTime, 0);
        }

        public void Walk()
        {
            Animator.CrossFade(AnimatorHelper.CHEF_WALK, TransitionTime, 0);
        }

        public void WalkWithPizza()
        {
            Animator.CrossFade(AnimatorHelper.CHEF_WALKWITHPIZZA, TransitionTime, 0);
        }

        private void UpdateSpeed()
        {
            if (Animator.GetCurrentAnimatorStateInfo(0).IsTag(AnimatorHelper.TAG_WALK))
            {
                SetAnimatorSpeed(MovementSpeed);
            }
            else if (Animator.GetCurrentAnimatorStateInfo(0).IsTag(AnimatorHelper.TAG_COOK))
            {
                SetAnimatorSpeed(CookSpeed);
            }
        }
    }
}