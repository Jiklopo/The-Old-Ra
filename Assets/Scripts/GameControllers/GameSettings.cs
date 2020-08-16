using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptable Objects/Game Settings")]
public class GameSettings : ScriptableObject
{
    public int mapRadius;
    public float attackInterval;
    public int regionsToGet;

}
