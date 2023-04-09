using Common.Scripts.ObserverPattern;

namespace Components.HealthBar.Scripts {
    public class HealthBarEntity : MonoBehaviourDataEmitter<HealthBarData>, IDataReceiver<float> {
        private HealthBarData _data;

        private void Start() {
            addReceivers(GetComponentsInChildren<IDataReceiver<HealthBarData>>());
            // _data = new HealthBarData(0, false);
            // emit();
        }

        public void receive(float value) {
            setHealthBarData(value);
            emit();
        }

        private void setHealthBarData(float value) {
            _data = new HealthBarData(
                value,
                value < 100
            );
        }

        public override void emit() {
            foreach (var dataReceiver in receivers) {
                dataReceiver.receive(_data);
            }
        }
    }
}