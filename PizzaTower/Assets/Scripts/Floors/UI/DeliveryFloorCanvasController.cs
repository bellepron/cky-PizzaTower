using PizzaTower.Managers;
using UnityEngine;

namespace PizzaTower.Floors.UI
{
    public class DeliveryFloorCanvasController : FloorCanvasControllerAbstract
    {
        [SerializeField] private GameObject buttonHolder;
        private DeliveryFloorSettings _deliveryFloorSettings;

        protected override void Start()
        {
            base.Start();
            _deliveryFloorSettings = LevelManager.Instance.levelSettings.DeliveryFloorSettings;
        }

        protected override void GetCosts()
        {
            costs = LevelManager.Instance.levelSettings.DeliveryFloorSettings.DeliveryFloorCosts;
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();

            EventManager.DeliveryFloorUpgrade += OnUpgrade;
        }

        protected override void OnUpgrade(int level)
        {
            if (level == _deliveryFloorSettings.DeliveryMaxLevel)
            {
                EventManager.DeliveryFloorUpgrade -= OnUpgrade;
                buttonHolder.SetActive(false);

                return;
            }

            base.OnUpgrade(level);
        }
    }
}