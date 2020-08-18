using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    [SerializeField] Treasure[] treasures;

    public static TreasureManager Instance { get; private set; }
    PlayerMoney money;
    private void Awake()
    {
        Instance = this;
        money = FindObjectOfType<PlayerMoney>();
    }

    public void TryGetTreasure()
    {
        float luck = Random.Range(0f, 1f);

        foreach(var t in treasures)
        {
            if(luck < t.chance)
            {
                money.Add(t.value);
                Debug.Log($"Player Found {t.name}");
                return;
            }
        }
    }


    [System.Serializable]
    struct Treasure
    {
        public string name;
        public Sprite sprite;
        public float chance;
        public int value;
    }
}
