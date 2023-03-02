using PizzaTower.Floors;
using UnityEngine;

namespace cky.Reuseables.Level
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level/New Level Settings")]
    public class LevelSettings : ScriptableObject
    {
        [field: SerializeField] public FloorSettings FloorSettings { get; private set; }
    }
}