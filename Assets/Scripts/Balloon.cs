using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public enum BalloonColors { Orange , Blue, Red, Purple, Green, Yellow};

    [Header("Balloon Properties")]
    public BalloonColors balloonColor;
    [Range(-.5f, 0f)] public float gravityScale;
    public GameObject popEffect;
    public float lifeTime = 10f;

    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = FindObjectOfType<Animator>();
        animator.SetInteger("balloonColorIndex", (int)balloonColor);

        rb = FindObjectOfType<Rigidbody2D>();
        rb.gravityScale = gravityScale;

    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            Vector3 pos = gameObject.transform.position;
            pos.y += .2f;
            Instantiate(popEffect, pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
