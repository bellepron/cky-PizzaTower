using UnityEngine;

namespace cky.Reuseables.Level
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level/New Level Settings")]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private float exampleSpeed;
        public float ExapleSpeed { get { return exampleSpeed; } set { exampleSpeed = value; } }
    }
}