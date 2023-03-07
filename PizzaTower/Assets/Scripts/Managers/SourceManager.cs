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
        string _coin;

        private void Start()
        {
            _coin = LevelManager.Instance.levelSettings.FloorCosts[0];

            UpdateCoinText();

            EventManager.AddCoin += AddCoin;
        }

        private void AddCoin(string value)
        {
            _coin = BigNumber.AddStringNumbers(_coin, value);

            UpdateCoinText();
        }

        private void UpdateCoinText()
        {
            coinTMP.text = _coin;
        }
    }
}