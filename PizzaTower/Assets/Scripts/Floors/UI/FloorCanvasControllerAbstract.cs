using PizzaTower.Managers;
using PizzaTower.Helpers;
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
            SubscribeEvents();
        }

        protected abstract void GetCosts();

        private void GetFirstValueOfButton() => UpdateUpgradeCostTMP(0);

        protected virtual void SubscribeEvents()
            => EventManager.UpdateActivationOfUpgradeButtons += UpdateActivationOfUpgradeButton;

        private void UpdateActivationOfUpgradeButton(string coinsInPossession)
        {
            if (BigNumber.IsBiggerOrEqual(coinsInPossession, upgradeCost))
                interactiveUpgradeButton.SetActive(true);
            else
                interactiveUpgradeButton.SetActive(false);
        }

        protected virtual void OnUpgrade(int level) => UpdateUpgradeCostTMP(level);

        protected void UpdateUpgradeCostTMP(int floorCount)
        {
            if (floorCount < costs.Length)
                upgradeCost = costs[floorCount];

            upgradeCostTMP.text = upgradeCost.Convert4();
        }
    }
}