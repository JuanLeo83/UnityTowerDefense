namespace Common.Scripts.ObserverPattern {
    public interface IDataReceiver<in T> {
        void receive(T value);
    }
}