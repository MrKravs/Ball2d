using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public bool IsTriggeredSpike;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out var ball) == false) return;

        Destroy(ball.gameObject);
    }
}
