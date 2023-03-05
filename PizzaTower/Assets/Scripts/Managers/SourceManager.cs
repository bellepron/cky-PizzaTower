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
        int _coin;

        private void Start()
        {
            _coin = LevelManager.Instance.levelSettings.FloorSettings.FloorUpgradeCosts[1];

            UpdateCoinText();

            EventManager.UpdateCoinEvent += UpdateCoin;
        }

        private void UpdateCoin(int value)
        {
            _coin += value;

            UpdateCoinText();
        }

        private void UpdateCoinText()
        {
            coinTMP.text = $"{_coin}";
        }
    }
}