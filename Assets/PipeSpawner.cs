using System.Threading;
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

        }else
        {
            SpawnPipe();
            timer = 0;

        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Vector2 RandomPos = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        Instantiate(pipePrefab, RandomPos, transform.rotation);
    }
}
