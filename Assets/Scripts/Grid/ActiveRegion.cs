using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class ActiveRegion : MonoBehaviour
{
    Grid grid;
    [SerializeField] Tile shadeTile;
    [SerializeField] Tilemap shadeTilemap;
    [SerializeField] List<Vector2Int> activeCells = new List<Vector2Int>();
    private void Awake()
    {
        grid = GetComponent<Grid>();
        for(int i = 50; i > -50; i--)
        {
            for (int j = 50; j > -50; j--)
            {
                Vector3Int cell = new Vector3Int(i, j, 0);
                if (IsCellActive(cell))
                    break;

                shadeTilemap.SetTile(cell, shadeTile);
            }
        }
    }

    public bool IsCellActive(Vector2Int cellPos)
    {
        return activeCells.Contains(cellPos);
    }

    public bool IsCellActive(Vector3Int cellPos)
    {
        return IsCellActive((Vector2Int)cellPos);
    }
}
