namespace Common.Scripts.ObserverPattern {
    public interface IDataEmitter<out T> {
        public void emit();
        public void addReceiver(IDataReceiver<T> dataReceiver);
        public void addReceivers(params IDataReceiver<T>[] dataReceivers);
        public void removeReceiver(IDataReceiver<T> dataReceiver);
    }
}