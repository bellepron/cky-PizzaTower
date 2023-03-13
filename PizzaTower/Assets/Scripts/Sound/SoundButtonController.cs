using System;
using UnityEngine;
using UnityEngine.UI;

namespace PizzaTower.Sound
{
    public class SoundButtonController : MonoBehaviour
    {
        public static Action<bool> SoundEvent;

        [SerializeField] GameObject soundOnGO;
        [SerializeField] Button soundOnButton;
        [SerializeField] Button soundOffButton;
        private const string _bIsSoundOnPp = "IsSoundOn";
        private int _bIsSoundOn;

        private void Start()
        {
            _bIsSoundOn = PlayerPrefs.GetInt(_bIsSoundOnPp);

            soundOnButton.onClick.AddListener(ActivateSound);
            soundOffButton.onClick.AddListener(ActivateSound);

            ActivateSound();
        }

        private void ActivateSound()
        {
            _bIsSoundOn = _bIsSoundOn == 0 ? 1 : 0;
            var activate = _bIsSoundOn == 1 ? true : false;
            soundOnGO.SetActive(activate);
            PlayerPrefs.SetInt(_bIsSoundOnPp, activate ? 1 : 0);

            SoundEvent?.Invoke(activate);
        }
    }
}