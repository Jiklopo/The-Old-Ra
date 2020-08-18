using UnityEngine;

public class Fence : GridObject
{
    [SerializeField] FenceState currentState;
    PlayerController player;
    GameSettings settings;
    float workTime = 1f;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public override void Activate()
    {
        switch (currentState)
        {
            case FenceState.UNBUILT:
                player.FreezeControlFor(workTime);
                currentState = FenceState.CONCRETE;
                return;
            case FenceState.CONCRETE:
                player.FreezeControlFor(workTime);
                currentState = FenceState.BUILT;
                return;
            case FenceState.BUILT:
                gameObject.SetActive(false);
                currentState = FenceState.UNBUILT;
                break;
        }
    }

    enum FenceState
    {
        UNBUILT,
        CONCRETE,
        BUILT
    }
}