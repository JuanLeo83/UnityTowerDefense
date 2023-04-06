using Components.Router.Scripts;
using UnityEngine;

namespace Components.Enemies.Scripts {
    public class Movement : MonoBehaviour {
        private Transform _transform;
        private Rigidbody2D _rigidBody;

        private RoutePoint _nextRoutePoint;
        private EnemyParams _enemyParams;
        private float _speed;

        public bool stop = false;

        private void Start() {
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody2D>();

            _enemyParams = GetComponent<EnemyParams>();
            _nextRoutePoint = _enemyParams.startPoint;
            _speed = _enemyParams.parameters.speed;
        }

        private void Update() {
            stop = !_enemyParams.isAlive();
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