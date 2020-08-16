using System.Collections;
using UnityEngine;

public class Babka : MonoBehaviour, IObserver
{
    GameSettings settings;
    int turnToAttack;
    Vector3Int cell;

    private void Awake()
    {
        settings = Resources.Load<GameSettings>("Scriptable Objects/Game Settings");
        turnToAttack = settings.attackInterval;
    }

    private void Start()
    {
        TurnManager.Instance.Subscribe(this);
        StartCoroutine(FindCellCoroutine());
    }

    void Attack()
    {
        ActiveRegion.Instance.DeactivateCell(cell);
        StartCoroutine(FindCellCoroutine());
    }

    IEnumerator FindCellCoroutine()
    {
        do
        {
            cell = new Vector3Int(Random.Range(-settings.mapRadius, settings.mapRadius), Random.Range(-settings.mapRadius, settings.mapRadius), 0);
        } while (ActiveRegion.Instance.CellCount > 0 && !ActiveRegion.Instance.IsCellActive(cell));
        yield return new WaitForEndOfFrame();
    }

    public void Notify()
    {
        turnToAttack--;
        if (turnToAttack <= 0)
        {
            turnToAttack = settings.attackInterval;
            Attack();
        }
    }
}
