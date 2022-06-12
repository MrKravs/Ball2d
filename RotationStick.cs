using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationStick : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _dirRotaion = 1;
    private AudioSource audioSource;
    public AudioClip audioClip;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Bullet");
    }
    void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * _dirRotaion * _speed));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
