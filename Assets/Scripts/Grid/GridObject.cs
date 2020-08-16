using UnityEngine;
using UnityEngine.Events;

public abstract class GridObject : MonoBehaviour
{
    [HideInInspector]
    public Vector3Int cellPos;
    public abstract void Activate();
}
