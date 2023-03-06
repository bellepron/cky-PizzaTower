using PizzaTower.Helpers;
using System.Linq;
using TMPro;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class FloorCanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI barTMP;
        [SerializeField] private TextMeshProUGUI upgradeCostTMP;
        [SerializeField] private GameObject interactiveUpgradeButton;
        [SerializeField] private GameObject buttonHolder;
        [SerializeField] private GameObject[] stars;
        private int _starsCount;
        private FloorController _floor;
        private FloorSettings _floorSettings;
        private string barTextConst;

        public void Initialize(FloorController floor)
        {
            _floor = floor;
            _floorSettings = floor.FloorSettings;
            barTextConst = $"Floor {floor.FloorOrder} - Level ";

            UpdateBarTMP(1);
            UpdateUpgradeCostTMP(1);

            floor.UpgradeEvent += Upgrade;
        }

        private void Upgrade(int floorLevel)
        {
            UpdateBarTMP(floorLevel);

            AddStar(floorLevel);

            if (floorLevel == _floorSettings.FloorMaxLevel)
            {
                _floor.UpgradeEvent -= Upgrade;
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

        private void UpdateUpgradeCostTMP(int floorLevel)
        {
            upgradeCostTMP.text = _floorSettings.FloorUpgradeCosts[floorLevel].Convert4();
        }
    }
}