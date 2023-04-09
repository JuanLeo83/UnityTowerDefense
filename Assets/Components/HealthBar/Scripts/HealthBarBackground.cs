using Common.Scripts.ObserverPattern;
using UnityEngine;

namespace Components.HealthBar.Scripts {
    public class HealthBarBackground : MonoBehaviour, IDataReceiver<HealthBarData> {
        private SpriteRenderer _renderer;

        private void Start() {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.enabled = false;
        }

        public void receive(HealthBarData value) {
            _renderer.enabled = value.IsVisible;
        }
    }
}