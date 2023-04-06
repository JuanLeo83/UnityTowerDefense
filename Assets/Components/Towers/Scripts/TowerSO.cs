using UnityEngine;

namespace Components.Towers.Scripts {
    [CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Tower", order = 0)]
    public class TowerSO : ScriptableObject {
        public int hp;
        public int attack;
        public float ratio;
        public float range;
    }
}