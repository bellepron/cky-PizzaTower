using cky.Reuseables.Singleton;
using System;

namespace cky.Reuseables.Managers
{
    public abstract class EventManagerAbstract : SingletonPersistent<EventManagerAbstract>
    {
        public static event Action /*UpdateEvent,*/ GameEnd, GameSuccess, GameFail;

        protected override void OnPerAwake() => ResetEvents();

        private void ResetEvents()
        {
            //UpdateEvent = null;
            GameEnd = null;
            GameSuccess = null;
            GameFail = null;
        }

        #region Core

        //private void Update() => UpdateEvent?.Invoke();
        public void GameEndEvent() => GameEnd?.Invoke();
        public void GameSuccessEvent() => GameSuccess?.Invoke();
        public void GameFailEvent() => GameFail?.Invoke();

        #endregion
    }
}