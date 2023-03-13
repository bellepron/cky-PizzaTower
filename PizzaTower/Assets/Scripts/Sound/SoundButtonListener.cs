using UnityEngine;

namespace PizzaTower.Sound
{
    public class SoundButtonListener : MonoBehaviour
    {
        AudioListener _audioListener;

        private void Start()
        {
            _audioListener = GetComponent<AudioListener>();

            SoundButtonController.SoundEvent += ActivateSound;
        }

        private void ActivateSound(bool activate)
        {
            _audioListener.enabled = activate;
        }
    }
}