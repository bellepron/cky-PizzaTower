using PizzaTower.Characters.DeliveryMan;
using PizzaTower.Floors;
using UnityEngine;

namespace cky.Reuseables.Level
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level/New Level Settings")]
    public class LevelSettings : ScriptableObject
    {
        [field: SerializeField] public FloorSettings FloorSettings { get; private set; }
        [field: SerializeField] public DeliveryFloorSettings DeliveryFloorSettings { get; private set; }
        [field: SerializeField] public DeliveryManSettings DeliveryManSettings { get; private set; }
    }
}