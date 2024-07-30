using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Rigidbody2D theRB;

    public float moveSpeed;
    [Header("Jump Info")]
    public float jumpForce;
    public Transform groundPoint;
    public LayerMask groundCheck;

    private bool isOnGround;

    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundCheck);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
    }
}
