using cky.Reuseables.Level;
using PizzaTower.Managers;
using TMPro;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class TopFloorCanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI barTMP;
        [SerializeField] private TextMeshProUGUI upgradeCostTMP;
        [SerializeField] private GameObject interactiveUpgradeButton;
        private LevelSettings _levelSettings;
        private int nextFLoorCost;

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
                nextFLoorCost = _levelSettings.FloorCosts[floorCount];
            }

            upgradeCostTMP.text = $"{nextFLoorCost}";
        }
    }
}