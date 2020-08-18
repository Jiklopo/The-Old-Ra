using UnityEngine;

public class PlayerMoney : ObservableMonoBehaviour
{
    public static PlayerMoney Instance { get; private set; }
    public int Money
    {
        get => money;
        private set
        {
            money = value;
            Notify();
        }
    }
    int money = 200;
    private void Awake()
    {
        Instance = this;
    }

    public bool Withdraw(int amount)
    {
        if (Money - amount < 0)
            return false;
        Money -= amount;
        return true;
    }

    public void Add(int amount)
    {
        Money += amount;
    }
}
