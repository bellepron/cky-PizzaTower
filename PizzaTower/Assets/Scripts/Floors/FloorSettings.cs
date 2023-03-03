using PizzaTower.Characters.Chef;
using UnityEngine;

namespace PizzaTower.Floors
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Floors/New Floor Settings")]
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
        [field: SerializeField] public int[] ChefAddLevels { get; private set; } = new int[3] { 1, 10, 20 };
        [field: SerializeField] public int[] StarAddLevels { get; private set; } = new int[5] { 10, 20, 30, 40, 50 };
        [field: SerializeField]
        public int[] FloorUpgradeCosts { get; private set; } = new int[50] {0,20,30,40,50,60,70,80,90,100,
                                                                            110,120,130,140,150,160,170,180,190,200,
                                                                            210,220,230,240,250,260,270,280,290,300,
                                                                            310,320,330,340,350,360,370,380,390,400,
                                                                            410,420,430,440,450,460,470,480,490,500};
    }
}