using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }
    public GameSettings Settings { get; private set; }

    private void Awake()
    {
        Instance = this;
        Settings = Resources.Load<GameSettings>("Scriptable Objects/Game Settings");
    }
}
