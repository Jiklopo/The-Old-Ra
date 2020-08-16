using UnityEngine;
using UnityEngine.Events;

public class ObserverMonoBehaviour: MonoBehaviour, IObserver
{
    [SerializeField] ObservableMonoBehaviour target;
    [SerializeField] UnityEvent OnNotify;
    private void Start()
    {
        target.Subscribe(this);
    }
    public void Notify()
    {
        OnNotify.Invoke();
    }
}
