using UnityEngine;

namespace Components.Enemies.Scripts {
    [CreateAssetMenu(fileName = "EnemyUnit", menuName = "ScriptableObjects/EnemyUnit")]
    public class EnemySO : ScriptableObject {
        public int hp;
        public int attack;
        public float speed;
        public EnemyType type;
    }
}