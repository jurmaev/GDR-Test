using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int spikesCount = 5;
    [SerializeField] private int coinsCount = 5;
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private GameObject coinPrefab;
    
    public int CoinsCount => coinsCount;
    void Start()
    {
        for (var i = 0; i < spikesCount; i++)
            Instantiate(spikePrefab, GenerateSpawnPos(), spikePrefab.transform.rotation);
        
        for (var i = 0; i < coinsCount; i++)
            Instantiate(coinPrefab, GenerateSpawnPos(), coinPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPos()
    {
        var x = Random.Range(0.05f, 0.95f);
        var y = Random.Range(0.05f, 0.95f);
        var pos = new Vector3(x, y, 10f);
        pos = Camera.main.ViewportToWorldPoint(pos);
        return pos;
    }
}
