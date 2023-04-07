using Components.Router.Scripts;
using UnityEngine;

namespace Components.Enemies.Scripts {
    public class EnemyEntity : MonoBehaviour {
        public static readonly string EnemyTag = "Enemy";
        
        public EnemySO parameters;
        public RoutePoint startPoint;

        public EnemyStatus State { get; private set; }

        private EnemyLifeController _lifeController;

        private void Start() {
            tag = EnemyTag;
            State = new EnemyStatus(parameters);
            _lifeController = new EnemyLifeController(this);
        }

        public void setDamage(int damage) {
            _lifeController.setDamage(damage);
        }
    }
}