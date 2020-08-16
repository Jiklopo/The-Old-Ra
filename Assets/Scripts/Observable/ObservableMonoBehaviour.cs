using System.Collections.Generic;
using UnityEngine;

public abstract class ObservableMonoBehaviour: MonoBehaviour
{
    List<Observer> observers = new List<Observer>();
    protected void Notify()
    {
        foreach (var o in observers)
            o.Notify();
    }

    public void Subscribe(Observer o)
    {
        observers.Add(o);
    }
}
