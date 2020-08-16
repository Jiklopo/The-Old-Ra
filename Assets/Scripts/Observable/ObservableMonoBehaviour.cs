using System.Collections.Generic;
using UnityEngine;

public abstract class ObservableMonoBehaviour: MonoBehaviour
{
    List<IObserver> observers = new List<IObserver>();
    protected void Notify()
    {
        foreach (var o in observers)
            o.Notify();
    }

    public void Subscribe(IObserver o)
    {
        observers.Add(o);
    }
}
