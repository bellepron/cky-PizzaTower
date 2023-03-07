using PizzaTower.Managers;
using UnityEngine;

namespace PizzaTower.Floors.UI
{
    public class DeliveryFloorCanvasController : FloorCanvasControllerAbstract
    {
        protected override void GetCosts()
        {
            costs = LevelManager.Instance.levelSettings.DeliveryFloorSettings.DeliveryFloorCosts;
        }

        protected override void SubscribeEvent()
        {
            EventManager.DeliveryFloorUpgrade += OnUpgrade;
        }
    }
}