using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool running;
    bool jumping;
    bool ducking;
    bool attacking;
    bool isDead;

    void Start()
    {

    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }
        else if (Input.GetButtonDown("Crouch"))
        {
            ducking = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            ducking = false;
        }

        

        if (Input.GetButtonDown("Fire1"))
        {
            attacking = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            attacking = false;
        }

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        animator.SetBool("jumping", jumping);
        animator.SetBool("ducking", ducking);
        animator.SetBool("attacking", attacking);
        animator.SetBool("isDead", isDead);
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, ducking, jumping);
        }
        jumping = false;
    }
}
