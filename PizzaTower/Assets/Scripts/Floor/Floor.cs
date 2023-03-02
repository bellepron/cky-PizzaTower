using System;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class Floor : MonoBehaviour
    {
        public event Action<int> UpgradeEvent;
        public ChefSpawner ChefSpawner { get; set; }
        private int _floorLevel;

        private void Start()
        {
            ChefSpawner = new ChefSpawner(this);
        }

        public void UpgradeFloor()
        {
            _floorLevel++;
            UpgradeEvent?.Invoke(_floorLevel);
        }
    }
}