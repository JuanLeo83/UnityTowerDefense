using System.Collections.Generic;
using UnityEngine;

namespace Common.Scripts.ObserverPattern {
    public abstract class MonoBehaviourDataEmitter<T> : MonoBehaviour, IDataEmitter<T> {
        protected readonly List<IDataReceiver<T>> receivers = new();
        
        public abstract void emit();

        public void addReceiver(IDataReceiver<T> dataReceiver) {
            receivers.Add(dataReceiver);
        }

        public void addReceivers(params IDataReceiver<T>[] dataReceivers) {
            foreach (var dataReceiver in dataReceivers) {
                receivers.Add(dataReceiver);
            }
        }

        public void removeReceiver(IDataReceiver<T> dataReceiver) {
            receivers.Remove(dataReceiver);
        }
    }
}