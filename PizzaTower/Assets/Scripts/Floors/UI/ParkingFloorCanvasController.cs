using PizzaTower.Managers;

namespace PizzaTower.Floors.UI
{
    public class ParkingFloorCanvasController : FloorCanvasControllerAbstract
    {
        protected override void GetCosts()
        {
            costs = LevelManager.Instance.levelSettings.FloorCosts;
        }

        protected override void SubscribeEvent()
        {
            EventManager.AddFloor += OnUpgrade;
        }
    }
}