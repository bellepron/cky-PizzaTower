using PizzaTower.Spawners;
using UnityEngine;

namespace PizzaTower.Managers
{
    public class GameManager : MonoBehaviour
    {
        FloorManager _floorManager;
        DeliveryManSpawner _deliveryManSpawner;
        private void Start()
        {
            _floorManager = new FloorManager();
            _deliveryManSpawner = new DeliveryManSpawner();
        }
    }
}