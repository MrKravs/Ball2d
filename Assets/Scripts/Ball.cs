﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField][Range(0, 20)]private int _timeBallLife;

    private float _startTime;

    private void Awake()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Color color = Settings.ParseCircleColorFromPP();
        sr.color = color;
    }

    private void Start()
    {
        _startTime = Time.time;
    }
    private void Update()
    {
        BallLife();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.gameObject.tag == "FinishPoint")
        {
            gameObject.GetComponent<Ball>().enabled = false;
            GameObject.Find("LevelsController").GetComponent<LevelsController>().SwitchLevel();
        }
    }
    private void BallLife()
    {
        if (Time.time - _startTime >= _timeBallLife)
        {
            Destroy(gameObject);
        }
    }
}
