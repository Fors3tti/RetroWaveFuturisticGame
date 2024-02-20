using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private GatherInput gatherInput;
    private Rigidbody2D rb;
    private Animator anim;

    private int direction = 1;
    private bool grounded = true;

    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    public Transform rightPoint;


    // Start is called before the first frame update
    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorValues();
    }

    private void FixedUpdate()
    {
        CheckStatus();
        Move();
        Jump();
    }

    private void Move()
    {
        Flip();
        rb.velocity = new Vector2(speed * gatherInput.moveInput, rb.velocity.y);
    }

    private void Jump()
    {
        if (gatherInput.jumpInput)
        {
            if (grounded)
            {
                rb.velocity = new Vector2(gatherInput.moveInput * speed, jumpForce);
            }
        }
        gatherInput.jumpInput = false;
    }

    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheckHit = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);
        if (leftCheckHit || rightCheckHit)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        SeeRays(leftCheckHit, rightCheckHit);
    }

    private void SeeRays(RaycastHit2D leftCheckHit, RaycastHit2D rightCheckHit)
    {
        Color color1 = leftCheckHit ? Color.red : Color.green;
        Color color2 = rightCheckHit ? Color.red : Color.green;

        Debug.DrawRay(leftPoint.position, Vector2.down * rayLength, color1);
        Debug.DrawRay(rightPoint.position, Vector2.down * rayLength, color2);

    }

    private void Flip()
    {
        if(gatherInput.moveInput * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }

    private void SetAnimatorValues()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("JumpSpeed", rb.velocity.y);
        anim.SetBool("Grounded", grounded);
    }
}
