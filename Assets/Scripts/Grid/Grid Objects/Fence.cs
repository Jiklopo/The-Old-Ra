using UnityEngine;

public class Fence : GridObject
{
    [SerializeField] FenceState currentState;
    public override void Activate()
    {
        throw new System.NotImplementedException();
    }

    enum FenceState
    {

    }
}