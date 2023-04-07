namespace Components.Enemies.Scripts {
    public class EnemyStatus {
        public int hp;
        public int attack;
        public float speed;
        public EnemyType type;

        public EnemyStatus(EnemySO parameters) {
            hp = parameters.hp;
            attack = parameters.attack;
            speed = parameters.speed;
            type = parameters.type;
        }

        public bool isAlive() => hp > 0;

        public void setHp(int value) {
            hp = value;
        }
    }
}