using UnityEngine;

namespace PizzaTower.Floors
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Floors/New Delivery Floor Settings")]
    public class DeliveryFloorSettings : ScriptableObject
    {
        [field: SerializeField] public Transform DeliveryManPrefabTr { get; private set; }
        [field: SerializeField] public Vector3 SpawnPoint { get; private set; } = new Vector3(10.0f, -14.4f, 0);
        [field: SerializeField] public Vector3 ParkingPoint { get; private set; } = new Vector3(-2.3f, -14.4f, 0);
        [field: SerializeField] public Vector3 DeliveryPoint { get; private set; } = new Vector3(10.0f, -14.4f, 0);
        [field: SerializeField] public int DeliveryMaxLevel { get; private set; } = 50;
        [field: SerializeField] public int[] DeliveryManAddLevels { get; private set; } = new int[11] { 1, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
    }
}