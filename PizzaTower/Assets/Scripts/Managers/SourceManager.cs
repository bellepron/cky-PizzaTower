using cky.Reuseables.Managers;
using PizzaTower.Helpers;
using TMPro;
using UnityEngine;

namespace PizzaTower.Managers
{
    public class SourceManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI coinTMP;
        [SerializeField] TextMeshProUGUI moneyTMP;
        [SerializeField] Transform coinIconTr;
        [SerializeField] Transform moneyIconTr;
        EventManager _eventManager;
        string _coin;

        private void Start()
        {
            _eventManager = (EventManager)EventManagerAbstract.Instance;
            _coin = LevelManager.Instance.levelSettings.FloorCosts[0];

            UpdateCoinText();
            UpdateActivationOfButtons();

            EventManager.AddCoin += AddCoin;
            EventManager.RemoveCoin += RemoveCoin;
        }

        private void AddCoin(string value)
        {
            _coin = BigNumber.AddStringNumbers(_coin, value);
            UpdateCoinText();

            UpdateActivationOfButtons();
        }

        private void RemoveCoin(string value)
        {
            _coin = BigNumber.SubtractStringNumbers(_coin, value);
            UpdateCoinText();

            UpdateActivationOfButtons();
        }

        private void UpdateCoinText()
        {
            coinTMP.text = _coin;
        }

        private void UpdateActivationOfButtons()
        {
            _eventManager.TriggerUpdateActivationOfUpgradeButtons(_coin);
        }
    }
}