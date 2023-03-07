using cky.Reuseables.Level;
using PizzaTower.Helpers;
using PizzaTower.Managers;
using TMPro;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class ParkingFloorCanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI upgradeCostTMP;
        [SerializeField] private GameObject interactiveUpgradeButton;
        private LevelSettings _levelSettings;
        private string nextUpgradeCost;

        private void Start()
        {
            _levelSettings = LevelManager.Instance.levelSettings;
            UpdateUpgradeCostTMP(0);

            EventManager.AddFloor += WhenFloorAdded;
        }

        private void WhenFloorAdded(int floorCount)
        {
            UpdateUpgradeCostTMP(floorCount);
        }

        private void UpdateUpgradeCostTMP(int floorCount)
        {
            if (floorCount < _levelSettings.FloorCosts.Length)
            {
                nextUpgradeCost = _levelSettings.FloorCosts[floorCount];
            }

            upgradeCostTMP.text = nextUpgradeCost.Convert4();
        }
    }
}