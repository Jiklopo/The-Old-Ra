using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class GridController : MonoBehaviour
{
    [SerializeField] Fence fencePrefab;
    Grid grid;
    Dictionary<Vector3Int, GridObject> objects = new Dictionary<Vector3Int, GridObject>();
    ActiveRegion activeRegion;

    private void Awake()
    {
        grid = GetComponent<Grid>();
        activeRegion = GetComponent<ActiveRegion>();

        foreach(var o in FindObjectsOfType<GridObject>())
        {
            var cellPos = grid.WorldToCell(o.transform.position);
            o.cellPos = cellPos;
            o.transform.position = (Vector3)cellPos * grid.cellSize.x;
            objects.Add(cellPos, o);
        }
    }
    public void ActivateCell(Vector3 worldPosition)
    {
        ActivateCell(grid.WorldToCell(worldPosition));
    }

    public void ActivateCell(Vector3Int cellPos)
    {
        if (!activeRegion.IsCellActive(cellPos))
            activeRegion.ActivateCell(cellPos);

        else if (objects.ContainsKey(cellPos))
            objects[cellPos].Activate();

        else
            Dig(cellPos);
    }

    void Dig(Vector3Int cellPos) {
        Fence fence = Instantiate(fencePrefab);
        fence.transform.position = (Vector3)cellPos * grid.cellSize.x;
        fence.cellPos = cellPos;
        objects.Add(cellPos, fence);
    }
}
