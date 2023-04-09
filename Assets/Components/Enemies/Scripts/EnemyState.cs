namespace Components.Enemies.Scripts {
    public class EnemyState {
        public int hp;
        public int attack;
        public float speed;
        public EnemyType type;

        public EnemyState(EnemySO parameters) {
            hp = parameters.hp;
            attack = parameters.attack;
            speed = parameters.speed;
            type = parameters.type;
        }

        public bool isAlive() => hp > 0;
    }
}