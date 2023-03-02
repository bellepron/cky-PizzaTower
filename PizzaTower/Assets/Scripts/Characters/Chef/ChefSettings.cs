using UnityEngine;

namespace PizzaTower.Characters.Chef
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Characters/New Chef Settings")]
    public class ChefSettings : ScriptableObject
    {
        [field: SerializeField] public float MovementSpeed { get; set; } = 1.0f;
        [field: SerializeField] public float CookTime { get; set; } = 5.0f;
    }
}