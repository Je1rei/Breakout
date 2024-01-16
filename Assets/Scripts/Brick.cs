using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Brick : MonoBehaviour
{
    [SerializeField] private int _live;

    private void Awake()
    {
        _live = RandomLive();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        _live--;

        if (ball != null && _live <= 0)
        {          
            DestroySelf();
            ball.IncreaseScore();
            ball.UpdatePlayerScoreText();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private int RandomLive() => Random.Range(1, 5);
}
