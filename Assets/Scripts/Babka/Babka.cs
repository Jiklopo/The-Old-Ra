using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Babka : MonoBehaviour, IObserver
{
    [SerializeField] Tile attackedZoneTile;
    [SerializeField] Tilemap tilemap;
    GameSettings settings;
    int turnToAttack;
    Vector3Int cell;

    private void Awake()
    {
    }

    private void Start()
    {
        settings = SettingsManager.Instance.Settings;
        turnToAttack = settings.attackInterval;
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
        tilemap.SetTile(cell, attackedZoneTile);
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
