using System.Collections;
using UnityEngine;

public class Babka : MonoBehaviour
{
    GameSettings settings;
    float time = 0;

    private void Awake()
    {
        settings = Resources.Load<GameSettings>("Scriptable Objects/Game Settings");
    }
    private void Update()
    {
        if(Time.time > time)
        {
            time = Time.time + settings.attackInterval;
            Attack();
        }

    }

    void Attack()
    {
        for (int i = 0; i < settings.regionsToGet; i++)
        {
            Vector3Int cell;
            do
            {
                cell = new Vector3Int(Random.Range(-settings.mapRadius, settings.mapRadius), Random.Range(-settings.mapRadius, settings.mapRadius), 0);
            } while (!ActiveRegion.Instance.IsCellActive(cell));
            ActiveRegion.Instance.DeactivateCell(cell);
        }
    }
}
