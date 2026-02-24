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
        Debug.Log("score zone hit");
        if (collision.gameObject.name == "PlayerShip")
        {
            logic.addScore();
        }
    }
}
