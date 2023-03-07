using PizzaTower.Characters.Chef;
using PizzaTower.Characters.DeliveryMan;
using PizzaTower.Characters.Elevator;
using PizzaTower.Floors;
using UnityEngine;

namespace cky.Reuseables.Level
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level/New Level Settings")]
    public class LevelSettings : ScriptableObject
    {
        [field: SerializeField] public FloorSettings FloorSettings { get; private set; }
        [field: SerializeField] public DeliveryFloorSettings DeliveryFloorSettings { get; private set; }
        [field: SerializeField] public ChefSettings[] ChefSettings { get; private set; }
        [field: SerializeField] public ElevatorSettings ElevatorSettings { get; private set; }
        [field: SerializeField] public DeliveryManSettings DeliveryManSettings { get; private set; }
        [field: SerializeField] public string PizzaCost { get; private set; } = "5";
        [field: SerializeField] public string[] FloorCosts { get; private set; } = new string[6] { "100", "175", "320", "500", "1250", "3800" };
    }
}