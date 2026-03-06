using JetBrains.Annotations;
using UnityEngine;

public class ScoreZoneScript : MonoBehaviour
{
    public  LogicManager logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            logic.AddScore(1);
        }
    }
}
