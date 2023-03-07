using cky.Reuseables.Managers;
using PizzaTower.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace PizzaTower.Floors
{
    public class DeliveryFloorUpgradeButton : MonoBehaviour
    {
        EventManager _eventManager;
        int _deliveryFloorLevel = 1;

        private void Start()
        {
            _eventManager = (EventManager)EventManagerAbstract.Instance;

            GetComponent<Button>().onClick.AddListener(IncreaseDeliveryLevel);
        }

        private void IncreaseDeliveryLevel()
        {
            _deliveryFloorLevel++;
            _eventManager.TriggerDeliveryFloorUpgrade(_deliveryFloorLevel);
        }
    }
}