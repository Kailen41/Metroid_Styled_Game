using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Components
    public static PlayerController instance;
    public float moveSpeed;

    [Header("Jump Info")]
    public float jumpForce;
    public Transform groundPoint;
    public LayerMask groundCheck;

    [Header("Bullet Info")]
    public BulletController shotToFire;
    public Transform shotPoint;

    private Animator theAnim;
    private Rigidbody2D theRB;
    private bool isOnGround;
    #endregion

    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        theAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        PlayerMovementAndAnimationController();
        PlayerFireWeapon();
    }

    private void PlayerFireWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDirection = new Vector2(transform.localScale.x, 0f);

            theAnim.SetTrigger("shotFired");
        }
    }

    private void PlayerMovementAndAnimationController()
    {
        // Move Sideways
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        // Handle direction change
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        // Checking if on the ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundCheck);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
        
        theAnim.SetBool("isOnGround", isOnGround);
        theAnim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
    }
}
