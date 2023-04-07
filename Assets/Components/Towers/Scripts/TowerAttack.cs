using System.Collections.Generic;
using Components.Enemies.Scripts;
using UnityEngine;

namespace Components.Towers.Scripts {
    public class TowerAttack : MonoBehaviour {
        [SerializeField] private List<EnemyEntity> enemiesInRange;

        private TowerSO _towerParams;

        private float _ratioCounter;

        private void Start() {
            _towerParams = GetComponent<TowerParams>().parameters;

            var circleCollider = GetComponent<CircleCollider2D>();
            circleCollider.radius = _towerParams.range;
        }

        private void Update() {
            _ratioCounter += Time.deltaTime;

            fire();
        }

        private void fire() {
            if (_ratioCounter < _towerParams.ratio || enemiesInRange.Count == 0) return;

            enemiesInRange[0].setDamage(_towerParams.attack);
            _ratioCounter = 0f;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag(EnemyEntity.EnemyTag)) return;

            var enemy = other.GetComponent<EnemyEntity>();
            enemiesInRange.Add(enemy);
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (!other.CompareTag(EnemyEntity.EnemyTag)) return;

            var enemy = other.GetComponent<EnemyEntity>();
            enemiesInRange.Remove(enemy);
        }
    }
}