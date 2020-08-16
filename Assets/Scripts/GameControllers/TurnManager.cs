using UnityEngine;

public class TurnManager : ObservableMonoBehaviour
{
    int turnNumber = 0;
    public static TurnManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void NextTurn()
    {
        turnNumber++;
        Notify();
    }
}
