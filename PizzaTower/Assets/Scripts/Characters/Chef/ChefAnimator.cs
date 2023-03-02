using PizzaTower.Floors;
using PizzaTower.Helpers;
using System;
using UnityEngine;

namespace PizzaTower.Characters.Chef
{
    public class ChefAnimator : MonoBehaviour
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public float TransitionTime { get; private set; }
        public float InitMoveSpeed { private get; set; }
        public float InitCookSpeed { private get; set; }
        public float MoveSpeed { private get; set; }
        public float CookSpeed { private get; set; }

        public void Initialize(Floor floor, float movementSpeed, float cookTime)
        {
            floor.UpgradeEvent += Upgrade;

            InitMoveSpeed = MoveSpeed = movementSpeed;
            InitCookSpeed = CookSpeed = 10 / cookTime;
        }

        private void Upgrade(int floorLevel)
        {
            MoveSpeed = InitMoveSpeed + (float)floorLevel * 0.1f;
            CookSpeed = InitCookSpeed + (float)floorLevel * 0.1f;

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
                SetAnimatorSpeed(MoveSpeed);
            }
            else if (Animator.GetCurrentAnimatorStateInfo(0).IsTag(AnimatorHelper.TAG_COOK))
            {
                SetAnimatorSpeed(CookSpeed);
            }
        }
    }
}