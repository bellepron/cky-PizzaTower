using UnityEngine;

namespace PizzaTower.Characters.Chef
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Characters/New Chef Settings")]
    public class ChefSettings : ScriptableObject
    {
        [field: SerializeField] public Transform ChefPrefabTr { get; private set; }
        [field: SerializeField] public Transform ChefsTablePrefabTr { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; } = 1.0f;
        [field: SerializeField] public float CookTime { get; private set; } = 5.0f;
        [field: SerializeField] public int PizzaCapacity { get; private set; } = 3;
    }
}