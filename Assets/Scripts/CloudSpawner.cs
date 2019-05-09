using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public float spawnDelaySeconds = 2.0f;
    public float spawnRangeY = 6.0f;
    public GameObject cloudPrefab
        ;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("AddCloud", 0, spawnDelaySeconds);
        AddCloud();
    }

    void AddCloud()
    {
        float x = transform.position.x;
        float y = transform.position.y + Random.Range(-spawnRangeY, spawnRangeY);

        Instantiate(cloudPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }
}
