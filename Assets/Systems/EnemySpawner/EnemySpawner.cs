using System.Collections.Generic;
using Components.Enemies.Scripts;
using Components.Router.Scripts;
using UnityEngine;

namespace Systems.EnemySpawner {
    public class EnemySpawner : MonoBehaviour {
        [SerializeField] private List<RoutePoint> spawnPoints;
        [SerializeField] private List<EnemyWaveSO> enemyWaves;
        [SerializeField] private EnemyEntity prefab;

        private int _waveCounter = 0;
        private EnemyWaveSO _nextWave;
        private float _timer;

        private int _nextSpawnPoint;

        private void Start() {
            _nextWave = enemyWaves[_waveCounter];
        }

        private void Update() {
            _timer += Time.deltaTime;
            instanceNextWave();
        }

        private void instanceNextWave() {
            if (wavesHasFinished() || _timer < _nextWave.delay) return;

            foreach (var enemyInWave in _nextWave.getWaves()) {
                var nextSpawnPosition = getNextSpawnPosition();

                prefab.parameters = enemyInWave.enemyType;
                prefab.startPoint = spawnPoints[_nextSpawnPoint];

                for (var n = 0; n < enemyInWave.amount; n++) {
                    Instantiate(
                        prefab,
                        randomizePositionInsideArea(nextSpawnPosition),
                        Quaternion.identity
                    );
                }
            }

            _timer = 0;
            _waveCounter++;
        }

        private bool wavesHasFinished() => enemyWaves.Count - 1 < _waveCounter;

        private Vector2 getNextSpawnPosition() {
            _nextSpawnPoint++;
            if (_nextSpawnPoint >= spawnPoints.Count) _nextSpawnPoint = 0;
            return spawnPoints[_nextSpawnPoint].transform.position;
        }

        private Vector2 randomizePositionInsideArea(Vector2 position) {
            var x = Random.Range(position.x - 1.5f, position.x + 1.5f);
            var y = Random.Range(position.y - 1.5f, position.y + 1.5f);
            return new Vector2(x, y);
        }
    }
}