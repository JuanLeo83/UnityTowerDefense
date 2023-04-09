using Common.Scripts.ObserverPattern;
using UnityEngine;

namespace Components.HealthBar.Scripts {
    public class CurrentHealthBar : MonoBehaviour, IDataReceiver<HealthBarData> {
        private float _initialScale;
        private SpriteRenderer _renderer;
        private Transform _transform;

        private void Start() {
            _transform = transform;
            _initialScale = _transform.localScale.x;
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.enabled = false;
        }

        public void receive(HealthBarData value) {
            setHealthBarLength(value.CurrentHealth);
            _renderer.enabled = value.IsVisible;
        }

        private void setHealthBarLength(float percentHealth) {
            var localScale = _transform.localScale;
            localScale.x = _initialScale * percentHealth / 100;
            _transform.localScale = localScale;
        }
    }
}