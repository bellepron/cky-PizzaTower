using UnityEngine;

namespace PizzaTower.Characters.DeliveryMan
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Characters/New Delivery Man Settings")]
    public class DeliveryManSettings : ScriptableObject
    {
        [field: SerializeField] public float MovementSpeed { get; private set; } = 1.5f;
        [field: SerializeField] public float GettingDeliveryTime { get; private set; } = 1.0f;
        [field: SerializeField] public int Capacity { get; private set; } = 10;
    }
}