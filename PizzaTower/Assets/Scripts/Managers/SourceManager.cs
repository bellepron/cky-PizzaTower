using cky.Reuseables.Managers;
using PizzaTower.Helpers;
using System;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                AddCoin("10000");
            }
        }

        private void Start()
        {
            _eventManager = (EventManager)EventManagerAbstract.Instance;
            Globals.CoinsInPossession = LevelManager.Instance.levelSettings.FloorCosts[0];

            UpdateCoinText();
            UpdateActivationOfButtons();

            EventManager.AddCoin += AddCoin;
            EventManager.RemoveCoin += RemoveCoin;
        }

        private void AddCoin(string value)
        {
            Globals.CoinsInPossession = BigNumber.AddStringNumbers(Globals.CoinsInPossession, value);
            UpdateCoinText();

            UpdateActivationOfButtons();
        }

        private void RemoveCoin(string value)
        {
            Globals.CoinsInPossession = BigNumber.SubtractStringNumbers(Globals.CoinsInPossession, value);
            UpdateCoinText();
        }

        private void UpdateCoinText()
        {
            coinTMP.text = BigNumber.Convert4(Globals.CoinsInPossession);
        }

        private void UpdateActivationOfButtons()
        {
            _eventManager.TriggerUpdateActivationOfUpgradeButtons();
        }
    }
}