using UnityEngine;

namespace PizzaTower.Screen
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Screen/New Screen Settings")]
    public class ScreenSettings : ScriptableObject
    {
        [field: SerializeField] public float ScrollHoldDuration { get; private set; } = 0.18f;
        [field: SerializeField] public int SwipeSpeed { get; private set; } = 1000;
        [field: SerializeField] public int SwipePixelClamp { get; private set; } = 30;

    }
}