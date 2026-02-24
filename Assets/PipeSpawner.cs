using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
   public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 1f;
    private float timer = 0;
    public LogicManager logic;

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;

        }else
        {
            Instantiate(pipePrefab, transform.position, transform.rotation);
            timer = 0;

        }
    }

}
