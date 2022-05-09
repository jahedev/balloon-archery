using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    AudioSource popSound;

    private void Awake()
    {
        popSound = FindObjectOfType<AudioSource>();
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            // logic here
        }
    }
}
