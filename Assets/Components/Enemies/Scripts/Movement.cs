using Components.Router.Scripts;
using UnityEngine;

namespace Components.Enemies.Scripts {
    public class Movement : MonoBehaviour {
        private Transform _transform;
        private Rigidbody2D _rigidBody;

        private RoutePoint _nextRoutePoint;
        private float _speed;

        private void Start() {
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody2D>();

            var enemyParams = GetComponent<EnemyParams>();
            _nextRoutePoint = enemyParams.startPoint;
            _speed = enemyParams.parameters.speed;
        }


        private void Update() {
            move();
        }

        private void move() {
            var position = _transform.position;
            var direction = _nextRoutePoint.transform.position - position;
            direction.Normalize();
            var movement = direction;
            _rigidBody.MovePosition(position + movement * (_speed * Time.deltaTime));
        }
    }
}