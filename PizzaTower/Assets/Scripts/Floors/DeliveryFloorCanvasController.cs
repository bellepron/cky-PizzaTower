using PizzaTower.Helpers;
using PizzaTower.Managers;
using TMPro;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class DeliveryFloorCanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI upgradeCostTMP;
        [SerializeField] private GameObject interactiveUpgradeButton;
        private string[] _deliveryFloorCosts;
        private string _nextUpgradeCost;

        private void Start()
        {
            _deliveryFloorCosts = LevelManager.Instance.levelSettings.DeliveryFloorSettings.DeliveryFloorCosts;
            UpdateUpgradeCostTMP(0);

            EventManager.DeliveryFloorUpgrade += Upgrade;
        }

        private void Upgrade(int deliveryFloorLevel)
        {
            UpdateUpgradeCostTMP(deliveryFloorLevel);
        }

        private void UpdateUpgradeCostTMP(int deliveryFloorLevel)
        {
            if (deliveryFloorLevel < _deliveryFloorCosts.Length)
            {
                _nextUpgradeCost = _deliveryFloorCosts[deliveryFloorLevel];
            }

            upgradeCostTMP.text = _nextUpgradeCost.Convert4();
        }
    }
}