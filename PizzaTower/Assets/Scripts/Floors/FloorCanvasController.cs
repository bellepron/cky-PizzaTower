using PizzaTower.Floors.UI;
using System.Linq;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class FloorCanvasController : FloorCanvasControllerAbstract
    {
        [SerializeField] private GameObject buttonHolder;
        [SerializeField] private GameObject[] stars;
        private int _starsCount;
        private FloorController _floor;
        private FloorSettings _floorSettings;
        private string barTextConst;

        private void Start() { }

        protected override void GetCosts()
        {
            costs = _floor.FloorSettings.FloorUpgradeCosts;
        }

        public void Initialize(FloorController floor)
        {
            _floor = floor;
            _floorSettings = floor.FloorSettings;
            barTextConst = $"Floor {floor.FloorOrder} - Level ";

            GetCosts();
            UpdateBarTMP(1);
            UpdateUpgradeCostTMP(1);

            SubscribeEvents();
            _floor.UpgradeEvent += OnUpgrade;
            _floor.UpgradeEvent += AddStar;
        }

        protected override void OnUpgrade(int floorLevel)
        {
            UpdateBarTMP(floorLevel);

            if (floorLevel == _floorSettings.FloorMaxLevel)
            {
                _floor.UpgradeEvent -= OnUpgrade;
                buttonHolder.SetActive(false);

                return;
            }

            UpdateUpgradeCostTMP(floorLevel);
        }

        private void AddStar(int floorLevel)
        {
            if (_floorSettings.StarAddLevels.Contains(floorLevel))
            {
                stars[_starsCount].SetActive(true);
                _starsCount++;
            }
        }

        private void UpdateBarTMP(int floorLevel)
        {
            barTMP.text = $"{barTextConst}{floorLevel}";
        }
    }
}