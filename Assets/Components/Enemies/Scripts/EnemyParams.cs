using Components.Router.Scripts;
using UnityEngine;

namespace Components.Enemies.Scripts {
    public class EnemyParams : MonoBehaviour {
        public static readonly string EnemyTag = "Enemy";
        
        public EnemySO parameters;
        public RoutePoint startPoint;

        private int _hp;
        private bool _alive = true;

        private void Start() {
            tag = EnemyTag;
            _hp = parameters.hp;
        }

        public void setDamage(int damage) {
            _hp -= damage;
            _alive = _hp > 0;
        }
        
        public bool isAlive() => _alive;
    }
}