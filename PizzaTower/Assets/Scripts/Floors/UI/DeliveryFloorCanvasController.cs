using PizzaTower.Managers;

namespace PizzaTower.Floors.UI
{
    public class DeliveryFloorCanvasController : FloorCanvasControllerAbstract
    {
        protected override void GetCosts()
        {
            costs = LevelManager.Instance.levelSettings.DeliveryFloorSettings.DeliveryFloorCosts;
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();

            EventManager.DeliveryFloorUpgrade += OnUpgrade;
        }
    }
}