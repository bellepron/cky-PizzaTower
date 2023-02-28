using cky.Reuseables.Singleton;
using cky.Reuseables.Managers;
using cky.Reuseables.Helpers;
using UnityEngine;

namespace cky.Reuseables.Level
{
    public class LevelManagerAbstract : SingletonPersistent<LevelManagerAbstract>
    {
        public LevelSettings[] levels;
        public LevelSettings levelSettings;

        int _levelIndex;

        protected override void OnPerAwake()
        {
            _levelIndex = PlayerPrefs.GetInt(PlayerPrefHelper.pPrefsLevelIndex);
            levelSettings = levels[_levelIndex % levels.Length];

            EventManagerAbstract.GameSuccess += OnGameSuccess;
        }

        private void Start()
        {
            _levelIndex = PlayerPrefs.GetInt(PlayerPrefHelper.pPrefsLevelIndex);
            levelSettings = levels[_levelIndex % levels.Length];

            EventManagerAbstract.GameSuccess += OnGameSuccess;
        }

        private void OnDisable()
        {
            EventManagerAbstract.GameSuccess -= OnGameSuccess;
        }

        private void OnGameSuccess()
        {
            _levelIndex++;
            PlayerPrefs.SetInt(PlayerPrefHelper.pPrefsLevelIndex, _levelIndex);
        }
    }
}