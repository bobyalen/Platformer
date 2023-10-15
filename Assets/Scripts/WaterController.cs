using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    BoxCollider2D box;


    [SerializeField] private LayerMask Ground;
    [SerializeField] float speed;
    [SerializeField] private float airvelocity;
    [SerializeField] private float acceleration;
    [SerializeField] float jumpForce;
    [SerializeField] float friction;
    [SerializeField] private AudioSource jump;


    private float xInput;
    public bool Right { get; private set; }
    float h = 0;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        // get the extent of the collision box
        box = GetComponent<BoxCollider2D>();
        Right = true;
    }
    void Update()
    {
        JumpControls();
    }

    void FixedUpdate()
    {
        h = playerInput();
        HorizontalMove();
        JumpControls();
    }

    void HorizontalMove()
    {
        float move = 0;
        float difference = (h * speed) - rigidBody.velocity.x;
            if (h != 0.0f)
            {
                Direction(h > 0);
                if (grounded())
                {
                    move = acceleration * difference;
                }
                else
                { 
                    move = airvelocity * difference;
                }
            }
        if (grounded())
        {
            move = (0.7f * acceleration) * difference;
        }
        else
        {
            move = (0.7f *airvelocity) * difference;
        }

        rigidBody.AddForce(move * Vector2.right, ForceMode2D.Force);
    }

    float playerInput()
    {
        float num = 0.0f;
        if (Input.GetKey("d"))
        {
            num = 1.0f;
        }
        if (Input.GetKey("a"))
        {
            num = -1.0f;
        }
        return num;
    }

    void JumpControls()
    {
        if (grounded())
        {
            rigidBody.gravityScale = 1f;
            if ((Input.GetKeyDown(KeyCode.W)))
            {
                Jump();
            }
        }
        if (((Input.GetKeyUp(KeyCode.W)) && !grounded()) || rigidBody.velocity.y < 0 && !grounded())
        {
            rigidBody.gravityScale = 2.5f;
        }
    }


    void Jump()
    {
        rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        jump.Play();

    }

    void Direction(bool isMovingRight)
    {
        if (isMovingRight != Right)
            DirectionChange();
    }

    void DirectionChange()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Right = !Right;
    }

    bool grounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 0.5f, Ground);
    }
}
