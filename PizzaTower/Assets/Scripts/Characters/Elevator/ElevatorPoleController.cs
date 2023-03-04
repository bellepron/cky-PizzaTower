using UnityEngine;

namespace PizzaTower.Characters.Elevator
{
    public class ElevatorPoleController : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Transform elevatorPoleStartTr;
        [SerializeField] private Transform elevatorPoleFinishTr;

        private void Update()
        {
            UpdatePole();
        }

        private void UpdatePole()
        {
            lineRenderer.SetPosition(0, elevatorPoleStartTr.position);
            lineRenderer.SetPosition(1, elevatorPoleFinishTr.position);
        }
    }
}