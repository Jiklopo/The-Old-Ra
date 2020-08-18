using UnityEngine;

public class Fence : GridObject
{
    [SerializeField] FenceState currentState;
    PlayerController player;
    float workTime = 1f;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public override void Activate()
    {
        switch (currentState)
        {
            case FenceState.PIT:
                player.FreezeControlFor(workTime);
                currentState = FenceState.CONCRETE;
                return;
            case FenceState.CONCRETE:
                player.FreezeControlFor(workTime);
                currentState = FenceState.BUILT;
                return;
            case FenceState.BUILT:
                gameObject.SetActive(false);
                currentState = FenceState.PIT;
                break;
        }
    }

    enum FenceState
    {
        PIT,
        CONCRETE,
        BUILT
    }
}