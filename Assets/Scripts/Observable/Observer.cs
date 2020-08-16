using UnityEngine;
using UnityEngine.Events;

public abstract class Observer: MonoBehaviour
{
    [SerializeField] ObservableMonoBehaviour target;
    private void Start()
    {
        target.Subscribe(this);
    }
    public abstract void Notify();
}
