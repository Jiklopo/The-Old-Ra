using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Babka : MonoBehaviour
{
    [SerializeField] Tile attackedZoneTile;
    [SerializeField] Tilemap tilemap;
    GameSettings settings;
    float time;
    Vector3Int cell;
    
    private void Start()
    {
        settings = SettingsManager.Instance.Settings;
        time = settings.attackInterval;
        StartCoroutine(FindCellCoroutine());
    }

    private void Update()
    {
        if(Time.time > time)
        {
            time = Time.time + settings.attackInterval;
            Attack();
        }
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
}
