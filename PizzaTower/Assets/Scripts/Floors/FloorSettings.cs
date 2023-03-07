using UnityEngine;

namespace PizzaTower.Floors
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Floors/New Floor Settings")]
    public class FloorSettings : ScriptableObject
    {
        [field: SerializeField] public Transform TopFloorPrefabTr { get; private set; }
        [field: SerializeField] public Transform FloorPrefabTr { get; private set; }
        [field: SerializeField] public float FloorOpeningTime { get; private set; } = 0.6f;
        [field: SerializeField] public float ChefOpeningTime { get; private set; } = 0.5f;
        [field: SerializeField] public float ChefsTableOpeningTime { get; private set; } = 0.6f;
        [field: SerializeField] public float FloorSupervisorOpeningTime { get; private set; } = 0.6f;
        [field: SerializeField] public float FloorSupervisorDeskOpeningTime { get; private set; } = 0.6f;
        [field: SerializeField] public float CanvasYellowBarOpeningTime { get; private set; } = 0.6f;
        [field: SerializeField] public float CanvasStarsOpeningInterval { get; private set; } = 0.2f;
        [field: SerializeField] public float CanvasStarsOpeningTime { get; private set; } = 0.15f;
        [field: SerializeField] public float CanvasUpgradeButtonOpeningTime { get; private set; } = 0.15f;
        public Vector3 FloorStartPos { get; private set; } = new Vector3(0, -10, 0);
        public Vector3 IncreaseQuantityOfFloor { get; private set; } = new Vector3(0, 4.2f, 0);
        public Vector3 TopFloorOffset { get; private set; } = new Vector3(0, 3.1f, 0);

        [field: SerializeField] public float ChefDeliveryPointX { get; private set; } = -2.5f;

        public Vector3[] ChefSpawnLocalPositions { get; private set; }
              = new Vector3[3] { new Vector3(4.3f, 0.416f, 0),
                                 new Vector3(4.3f - 1.256f, 0.416f, 0),
                                 new Vector3(4.3f - 1.256f - 1.256f, 0.416f, 0) };

        [field: SerializeField] public int FloorMaxLevel { get; private set; } = 50;
        [field: SerializeField] public int[] ChefAddLevels { get; private set; } = new int[3] { 1, 10, 20 };
        [field: SerializeField] public int[] StarAddLevels { get; private set; } = new int[5] { 10, 20, 30, 40, 50 };
        [field: SerializeField]
        public string[] FloorUpgradeCosts { get; private set; } = new string[50] {"0","20","30","4000","50000","600000","7000000","80000000","900000000","1000000000",
                                                                                  "0","20","30","40","50","60","70","80","90","100",
                                                                                  "0","20","30","40","50","60","70","80","90","100",
                                                                                  "0","20","30","40","50","60","70","80","90","100",
                                                                                  "0","20","30","40","50","60","70","80","90","100"};
    }
}