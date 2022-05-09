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

    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = FindObjectOfType<Animator>();
        animator.SetInteger("balloonColorIndex", (int)balloonColor);

        Debug.Log((int)balloonColor);

        rb = FindObjectOfType<Rigidbody2D>();
        rb.gravityScale = gravityScale;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            Debug.Log("Arrow Hit");
            Vector3 pos = gameObject.transform.position;
            pos.y += .2f;
            Instantiate(popEffect, pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
