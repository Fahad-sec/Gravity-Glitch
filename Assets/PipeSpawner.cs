using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 10;
    private float timer = 0;
    public LogicManager logic;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;

        }
        else
        {
            SpawnPipe();
            timer = 0;

        }
    }
    public float lowestVisiblePoint = -7;
    public float highestVisiblePoint = 7;
    void SpawnPipe()
    {
        float randomY = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);
        float cappedY = Mathf.Clamp(randomY, lowestVisiblePoint, highestVisiblePoint);


        Vector2 spawnPos = new Vector3(transform.position.x, cappedY, 0);
        Instantiate(pipePrefab, spawnPos, transform.rotation);
    }
}
