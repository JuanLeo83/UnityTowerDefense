using Components.Enemies.Scripts;

namespace Systems.EnemySpawner {
    public class EnemyInWave {

        public readonly EnemySO enemyType;
        public readonly int amount;
        
        public EnemyInWave(EnemySO enemyType, int amount) {
            this.enemyType = enemyType;
            this.amount = amount;
        }
    }
}