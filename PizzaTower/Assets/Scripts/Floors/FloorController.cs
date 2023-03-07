using DG.Tweening;
using PizzaTower.Characters.FloorSupervisor;
using PizzaTower.Helpers;
using PizzaTower.Interfaces;
using PizzaTower.Managers;
using PizzaTower.Spawners;
using System;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class FloorController : MonoBehaviour
    {
        public event Action<int> UpgradeEvent;
        public event Action<IPizzaHolder> AddPizzaToFloorSupervisor;

        public FloorSettings FloorSettings { get; private set; }
        [field: SerializeField] public FloorCanvasController FloorCanvasController { get; private set; }
        [field: SerializeField] public FloorSupervisorController FloorSupervisor { get; private set; }
        public int FloorOrder { get; set; }

        private ChefSpawner chefSpawner;

        [SerializeField] private Transform floorSupervisorTr;
        [SerializeField] private Transform floorSupervisorDeskTr;

        private int _floorLevel = 1;

        private void Start()
        {
            FloorSettings = LevelManager.Instance.levelSettings.FloorSettings;
            FloorCanvasController?.Initialize(this);
            chefSpawner = new ChefSpawner(this, FloorSupervisor);
            FloorSupervisor?.SubscribeToPizzaDeliveredEvent(this);

            FloorSupervisorOpeningAnimation();
        }

        public void UpgradeFloor()
        {
            _floorLevel++;
            UpgradeEvent?.Invoke(_floorLevel);
        }

        public void TriggerAddPizzaToFloorSupervisor(IPizzaHolder chef)
        {
            AddPizzaToFloorSupervisor?.Invoke(chef);
        }

        private void FloorSupervisorOpeningAnimation()
        {
            var floorSupervisorScale = floorSupervisorTr.localScale;
            var floorSupervisorDeskScale = floorSupervisorDeskTr.localScale;
            floorSupervisorTr.localScale = Vector3.zero;
            floorSupervisorDeskTr.localScale = new Vector3(floorSupervisorDeskTr.localScale.x, 0, 0);
            var delay = FloorSettings.FloorOpeningTime + FloorSettings.ChefsTableOpeningTime + FloorSettings.ChefOpeningTime;

            DOVirtual.DelayedCall(delay,
                () => floorSupervisorDeskTr.TableOpeningAnimation(floorSupervisorDeskScale, FloorSettings.FloorSupervisorDeskOpeningTime)
                .OnComplete(() => floorSupervisorTr.StaffOpeningAnimation(floorSupervisorScale, FloorSettings.FloorSupervisorDeskOpeningTime)));
        }
    }
}