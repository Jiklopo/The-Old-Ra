using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Babka : MonoBehaviour
{
    [SerializeField] Tile attackedZoneTile;
    [SerializeField] Tilemap tilemap;
    float attackInterval => GameVariables.Instance.AttackInterval;
    int mapRadius => GameVariables.Instance.MapRadius;
    ActiveRegion activeRegion => ActiveRegion.Instance;
    float time;
    Vector3Int cell;
    
    private void Start()
    {
        time = attackInterval;
        StartCoroutine(FindCellCoroutine());
    }

    private void Update()
    {
        if(Time.time > time)
        {
            time = Time.time + attackInterval;
            Attack();
        }
    }

    void Attack()
    {
        if (activeRegion.CellCount == 0)
            return;
        activeRegion.DeactivateCell(cell);
        StartCoroutine(FindCellCoroutine());
    }

    IEnumerator FindCellCoroutine()
    {
        do
        {
            cell = new Vector3Int(Random.Range(-mapRadius, mapRadius), Random.Range(-mapRadius, mapRadius), 0);
        } while (activeRegion.CellCount > 0 && !activeRegion.IsCellActive(cell));
        tilemap.SetTile(cell, attackedZoneTile);
        yield return new WaitForEndOfFrame();
    }
}
