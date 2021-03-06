﻿using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    [HideInInspector]
    public Vector3Int cellPos;
    public abstract void Activate();
}
