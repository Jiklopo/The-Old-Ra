using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class ActiveRegion : MonoBehaviour
{
    Grid grid;
    [SerializeField] Tile shadeTile;
    [SerializeField] Tilemap tilemap;
    [SerializeField] int radius = 30;
    [SerializeField] List<Vector3Int> activeCells = new List<Vector3Int>();
    public static ActiveRegion Instance { get; private set; }
    public int CellCount => activeCells.Count;
    private void Awake()
    {
        Instance = this;
        grid = GetComponent<Grid>();
        for(int i = radius; i > -radius; i--)
        {
            for (int j = radius; j > -radius; j--)
            {
                Vector3Int cell = new Vector3Int(i, j, 0);
                if (IsCellActive(cell))
                    continue;

                tilemap.SetTile(cell, shadeTile);
            }
        }
    }

    public bool IsCellActive(Vector3Int cellPos)
    {
        return activeCells.Contains(cellPos);
    }

    public bool ActiveNeighbours(Vector3Int cellPos)
    {
        for(int i = -1; i <= 1; i++)
        {
            if (i == 0)
                continue;

            if (activeCells.Contains(new Vector3Int(cellPos.x + i, cellPos.y, 0))
                || activeCells.Contains(new Vector3Int(cellPos.x, cellPos.y + i, 0)))
                return true;
        }
        return false;
    }

    public void ActivateCell(Vector3Int cellPos)
    {
        if (!ActiveNeighbours(cellPos) || !PlayerMoney.Instance.Withdraw(50))
            return;

        activeCells.Add(cellPos);
        tilemap.SetTile(cellPos, null);
    }

    public void DeactivateCell(Vector3Int cellPos)
    {
        activeCells.Remove(cellPos);
        tilemap.SetTile(cellPos, shadeTile);
    }
}
