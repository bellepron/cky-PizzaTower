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
        [field: SerializeField] public int[] DeliveryManAddLevels { get; private set; } = new int[11] { 1, 2, 5, 10, 20, 25, 30, 35, 40, 45, 50 };
        [field: SerializeField] public string[] DeliveryFloorCosts { get; private set; } = new string[11] { "175", "520", "12500", "250000", "3800000", "52000000", "700000000", "4700000000", "28000000000", "150000000000", "4400000000000" };
        public int DeliveryMaxLevel { get { return DeliveryFloorCosts.Length; } }
    }
}