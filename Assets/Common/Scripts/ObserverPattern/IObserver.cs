namespace Common.Scripts.ObserverPattern {
    public interface IObserver<in T> {
        void receive(T value);
    }
}