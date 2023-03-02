using PizzaTower.Characters.Chef;
using UnityEngine;

namespace PizzaTower.Floors
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Floor/New Floor Settings")]
    public class FloorSettings : ScriptableObject
    {
        [field: SerializeField] public Transform ChefPrefabTr { get; private set; }
        [field: SerializeField] public Transform ChefsTablePrefabTr { get; private set; }
        [field: SerializeField] public float ChefDeliveryPointX { get; private set; } = -2.5f;

        [field: SerializeField]
        public Vector3[] ChefSpawnLocalPositions { get; private set; }
              = new Vector3[3] { new Vector3(4.3f, 0.416f, 0),
                                 new Vector3(4.3f - 1.256f, 0.416f, 0),
                                 new Vector3(4.3f - 1.256f - 1.256f, 0.416f, 0) };

        [field: SerializeField] public ChefSettings[] ChefSettings { get; private set; }
        [field: SerializeField] public int FloorMaxLevel { get; private set; } = 50;
        [field: SerializeField] public int[] ChefAddLevels { get; private set; } = new int[3] { 0, 10, 50 };
        [field: SerializeField] public int[] StarAddLevels { get; private set; } = new int[5] { 10, 20, 30, 40, 50 };
    }
}