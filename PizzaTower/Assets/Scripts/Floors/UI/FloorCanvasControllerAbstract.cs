using PizzaTower.Helpers;
using PizzaTower.Managers;
using TMPro;
using UnityEngine;

namespace PizzaTower.Floors.UI
{
    public abstract class FloorCanvasControllerAbstract : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI barTMP;
        [SerializeField] protected TextMeshProUGUI upgradeCostTMP;
        [SerializeField] protected GameObject interactiveUpgradeButton;
        protected string[] costs;
        protected string upgradeCost;

        private void Start()
        {
            GetCosts();
            UpdateUpgradeCostTMP(0);
            SubscribeEvent();
        }

        protected abstract void GetCosts();
        private void GetFirstValueOfButton() => UpdateUpgradeCostTMP(0);
        protected abstract void SubscribeEvent();

        protected void OnUpgrade(int level) => UpdateUpgradeCostTMP(level);

        private void UpdateUpgradeCostTMP(int floorCount)
        {
            if (floorCount < costs.Length)
                upgradeCost = costs[floorCount];

            upgradeCostTMP.text = upgradeCost.Convert4();
        }
    }
}