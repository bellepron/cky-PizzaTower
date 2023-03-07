using PizzaTower.Spawners;
using UnityEngine;

namespace PizzaTower.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            new FloorSpawner();
            new DeliveryManSpawner();
        }
    }
}