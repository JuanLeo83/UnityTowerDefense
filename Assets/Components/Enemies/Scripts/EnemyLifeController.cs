namespace Components.Enemies.Scripts {
    public class EnemyLifeController {
        private readonly EnemyEntity _entity;

        public EnemyLifeController(EnemyEntity entity) => _entity = entity;

        public void setDamage(int damage) {
            _entity.State.setHp(_entity.State.hp - damage);
            _entity.gameObject.SetActive(_entity.State.isAlive());
        }
    }
}