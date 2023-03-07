using PizzaTower.Managers;

namespace PizzaTower.Floors.UI
{
    public class TopFloorCanvasController : FloorCanvasControllerAbstract
    {
        protected override void GetCosts()
        {
            costs = LevelManager.Instance.levelSettings.FloorCosts;
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();

            EventManager.AddFloor += OnUpgrade;
        }
    }
}