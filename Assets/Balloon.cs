using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public enum BalloonColors { Orange , Blue, Red, Purple, Green, Yellow};

    [Header("Balloon Properties")]
    public BalloonColors balloonColor;
    [Range(-.5f, 0f)] public float gravityScale;

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
}
