using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        float moveDirectionH = Input.GetAxis("Horizontal");
        float moveDirectionV = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveDirectionH * speed, moveDirectionV * speed);
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;

        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpForce > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }

        }
        transform.Translate(Input.GetAxis("Horizontal") * 10f * Time.deltaTime, 0f, 0f);
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;

        }
        transform.localScale=characterScale;

    }
   
}
