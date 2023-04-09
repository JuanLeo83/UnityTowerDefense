using Components.HealthBar.Scripts;
using Components.Router.Scripts;
using UnityEngine;

namespace Components.Enemies.Scripts {
    public class EnemyEntity : MonoBehaviour {
        public static readonly string EnemyTag = "Enemy";

        public EnemySO parameters;
        public RoutePoint startPoint;

        public EnemyState State { get; private set; }

        private EnemyHealthController _healthController;

        private void Start() {
            tag = EnemyTag;
            name = parameters.name;
            State = new EnemyState(parameters);
            _healthController = new EnemyHealthController(this);
            _healthController.addReceiver(GetComponentInChildren<HealthBarEntity>());
        }

        public void setDamage(int damage) {
            _healthController.setDamage(damage);
        }
    }
}