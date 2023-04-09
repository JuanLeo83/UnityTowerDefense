using Common.Scripts.ObserverPattern;

namespace Components.Enemies.Scripts {
    public class EnemyHealthController : DataEmitter<float> {
        private readonly EnemyEntity _entity;

        public EnemyHealthController(EnemyEntity entity) => _entity = entity;

        public void setDamage(int damage) {
            _entity.State.hp -= damage;
            _entity.gameObject.SetActive(_entity.State.isAlive());
            emit();
        }

        public override void emit() {
            var healthPercent = _entity.State.hp * 100f / _entity.parameters.hp;
            foreach (var observer in receivers) {
                observer.receive(healthPercent);
            }
        }
    }
}