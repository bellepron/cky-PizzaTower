using cky.Reuseables.Managers;
using PizzaTower.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace PizzaTower.Floors
{
    public class AddFloorButton : MonoBehaviour
    {
        EventManager _eventManager;
        int _floorOrder;

        private void Start()
        {
            _eventManager = (EventManager)EventManagerAbstract.Instance;

            GetComponent<Button>().onClick.AddListener(AddFloor);
        }

        private void AddFloor()
        {
            _floorOrder++;
            _eventManager.TriggerAddFloor(_floorOrder);
        }
    }
}