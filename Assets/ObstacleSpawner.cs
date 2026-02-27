using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public  float spawnRate = 4f;
    public float heightOffset = 3;
    private float timer = 0;
    public float obstacleGapScale = 1;
    public LogicManager logic;

    void Start()
    {
        SpawnObstacle();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;

        }
        else
        {
            SpawnObstacle();
            timer = 0;

        }
    }
    public float lowestVisiblePoint = -7;
    public float highestVisiblePoint = 7;
    void SpawnObstacle()
    {
        float randomY = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);
        float cappedY = Mathf.Clamp(randomY, lowestVisiblePoint, highestVisiblePoint);
        Vector2 spawnPos = new Vector3(transform.position.x, cappedY, 0);

        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, transform.rotation);
        newObstacle.transform.localScale = new Vector3(1, obstacleGapScale, 1);

    }
}
