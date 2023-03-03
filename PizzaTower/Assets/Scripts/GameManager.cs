using PizzaTower.Spawners;
using UnityEngine;

namespace PizzaTower.Managers
{
    public class GameManager : MonoBehaviour
    {
        DeliveryManSpawner _deliveryManSpawner;
        private void Start()
        {
            _deliveryManSpawner = new DeliveryManSpawner();
        }
    }
}