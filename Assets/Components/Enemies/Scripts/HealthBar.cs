using Common.Scripts.ObserverPattern;
using UnityEngine;

namespace Components.Enemies.Scripts {
    public class HealthBar : MonoBehaviour, IObserver<float> {
        private float _initialScale;

        private void Start() {
            _initialScale = transform.localScale.x;
        }

        public void receive(float value) {
            var transformLocalScale = transform.localScale;
            transformLocalScale.x = setHealthBarLength(value);
            transform.localScale = transformLocalScale;
        }

        private float setHealthBarLength(float percentHealth) {
            return _initialScale * percentHealth / 100;
        }
    }
}