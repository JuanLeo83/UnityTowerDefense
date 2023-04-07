using Components.Router.Scripts;
using UnityEngine;

namespace Components.Enemies.Scripts {
    public class Movement : MonoBehaviour {
        private Transform _transform;
        private Rigidbody2D _rigidBody;

        private RoutePoint _nextRoutePoint;
        private EnemyEntity _enemyEntity;
        private float _speed;

        public bool stop;

        private void Start() {
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody2D>();

            _enemyEntity = GetComponent<EnemyEntity>();
            _nextRoutePoint = _enemyEntity.startPoint;
            _speed = _enemyEntity.parameters.speed;
        }

        private void Update() {
            stop = !_enemyEntity.State.isAlive();
            move();
        }

        private void move() {
            if (stop) return;
            
            var position = _transform.position;
            var direction = _nextRoutePoint.transform.position - position;
            direction.Normalize();
            var movement = direction;
            _rigidBody.MovePosition(position + movement * (_speed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag(RouteCreator.RoutePointTag)) return;
            
            var next = _nextRoutePoint.getNextPoint();
            if (next == null) {
                stop = true;
                return;
            }
            
            _nextRoutePoint = next;
        }
    }
}