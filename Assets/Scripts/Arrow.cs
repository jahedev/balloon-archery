using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    Score score;

    void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            Debug.Log("updating score");
            score.UpdateScore(1);
        }
    }
}
