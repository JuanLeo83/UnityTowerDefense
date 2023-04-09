using System.Collections.Generic;

namespace Common.Scripts.ObserverPattern {
    public abstract class Observable<T> {
        protected readonly List<IObserver<T>> observers = new();
        
        public abstract void emit();
        public abstract void addObserver(IObserver<T> observer);
        public abstract void removeObserver(IObserver<T> observer);
    }
}