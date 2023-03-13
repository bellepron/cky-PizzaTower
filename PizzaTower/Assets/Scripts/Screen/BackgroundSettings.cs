using UnityEngine;

namespace PizzaTower.Screen
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Screen/New Background Settings")]

    public class BackgroundSettings : ScriptableObject
    {
        [field: SerializeField] public Transform BackgroundPrefabTr { get; private set; }
        [field: SerializeField] public float StartPosY { get; private set; } = 4.34f;
        [field: SerializeField] public float IncreaseAmountY { get; private set; } = 11.76f;
    }
}