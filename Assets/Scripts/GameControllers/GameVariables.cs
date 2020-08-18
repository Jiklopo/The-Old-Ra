using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    [SerializeField] int mapRadius;
    public int MapRadius => mapRadius;
    [SerializeField] float attackInterval;
    public float AttackInterval => attackInterval;
    [SerializeField] int startRadius;
    public int StartRadius => startRadius;
    public static GameVariables Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
