using UnityEngine;

namespace PizzaTower.Helpers
{
    public class AnimatorHelper
    {
        public static readonly int CHEF_COOK = Animator.StringToHash("Chef Cook");
        public static readonly int CHEF_WALK = Animator.StringToHash("Chef Walk");
        public static readonly int CHEF_WALKWITHPIZZA = Animator.StringToHash("Chef Walk With Pizza");

        public const string TAG_WALK = "Walk";
        public const string TAG_COOK = "Cook";
    }
}