using System.Collections.Generic;
using System.Linq;
using Components.Enemies.Scripts;
using UnityEngine;

namespace Systems.EnemySpawner {
    [CreateAssetMenu(fileName = "EnemyWaveSO", menuName = "ScriptableObjects/EnemyWave", order = 0)]
    public class EnemyWaveSO : ScriptableObject {
        public int delay = 30; //seconds

        public List<EnemySO> enemyList;
        public List<int> enemyAmount;

        public List<EnemyInWave> getWaves() {
            return enemyList.Select((enemyType, index) => new EnemyInWave(enemyType, enemyAmount[index])).ToList();
        }
    }
}