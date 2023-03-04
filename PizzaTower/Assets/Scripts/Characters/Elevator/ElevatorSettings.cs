using UnityEngine;

namespace PizzaTower.Characters.Elevator
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Characters/New Elevator Settings")]
    public class ElevatorSettings : ScriptableObject
    {
        [field: SerializeField] public float UpSpeed { get; private set; } = 7;
        [field: SerializeField] public float DownSpeed { get; private set; } = 5;
    }
}