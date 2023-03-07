using PizzaTower.Managers;
using PizzaTower.Helpers;
using TMPro;
using UnityEngine;
using cky.Reuseables.Managers;

namespace PizzaTower.Floors.UI
{
    public abstract class FloorCanvasControllerAbstract : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI barTMP;
        [SerializeField] protected TextMeshProUGUI upgradeCostTMP;
        [SerializeField] protected GameObject interactiveUpgradeButton;
        protected string[] costs;
        protected string upgradeCost;
        EventManager _eventManager;

        protected virtual void Start()
        {
            GetCosts();
            GetEventManager();
            GetFirstValueOfButton();
            SubscribeEvents();
        }

        protected abstract void GetCosts();

        protected void GetEventManager()
            => _eventManager = (EventManager)EventManagerAbstract.Instance;

        protected virtual void GetFirstValueOfButton() => UpdateUpgradeCost(0);

        protected virtual void SubscribeEvents()
            => EventManager.UpdateActivationOfUpgradeButtons += UpdateActivationOfUpgradeButton;

        protected void UpdateActivationOfUpgradeButton()
        {
            if (BigNumber.IsBiggerOrEqual(Globals.CoinsInPossession, upgradeCost))
                interactiveUpgradeButton.SetActive(true);
            else
                interactiveUpgradeButton.SetActive(false);
        }

        protected virtual void OnUpgrade(int level)
        {
            _eventManager.TriggerRemoveCoin(upgradeCost);

            UpdateUpgradeCost(level);

            _eventManager.TriggerUpdateActivationOfUpgradeButtons();
        }

        protected void UpdateUpgradeCost(int level)
        {
            if (level < costs.Length)
                upgradeCost = costs[level];

            upgradeCostTMP.text = upgradeCost.Convert4();
        }
    }
}