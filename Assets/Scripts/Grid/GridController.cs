using UnityEngine;

[RequireComponent(typeof(Grid))]
public class GridController : MonoBehaviour
{
    Grid grid;
    GridObject[] objects;
    ActiveRegion activeRegion;

    private void Awake()
    {
        grid = GetComponent<Grid>();
        activeRegion = GetComponent<ActiveRegion>();
        objects = FindObjectsOfType<GridObject>();
        foreach(var o in objects)
        {
            //o.transform.SetParent(transform);
            var cellPos = grid.WorldToCell(o.transform.position);
            o.cellPos = cellPos;
            o.transform.position = (Vector3)cellPos * grid.cellSize.x;
        }
    }

    public void ActivateCell(Vector2Int cellPos)
    {
        foreach(var o in objects)
        {
            if (o.cellPos.Equals(cellPos))
            {
                o.Activate();
                return;
            }
        }
    }
}
