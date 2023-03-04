using cky.Reuseables.Managers;
using PizzaTower.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PizzaTower.Floors
{
    public class AddFloorButton : MonoBehaviour
    {
        EventManager _eventManager;

        private void Start()
        {
            _eventManager = (EventManager)EventManagerAbstract.Instance;

            GetComponent<Button>().onClick.AddListener(AddFloor);
        }

        private void AddFloor()
        {
            _eventManager.AddFloorEvent();
        }
    }
}