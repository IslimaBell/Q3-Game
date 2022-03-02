using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefinedMovement : MonoBehaviour
{

    //jump
    float coyoteRemember = 0;
    [SerializeField]
    float coyoteTime = 0.25f;

    float jumpStorage = 0;
    [SerializeField]
    float jumpStorageTime = 0.25f;

    private int extraJumps;
    [SerializeField]
    private int extraJumpsValue;

    [SerializeField]
    private float jumpCut = 0.5f;
    public LayerMask ground;
    [SerializeField]
    private float jumpPower = 1f;

    //move
    private float horizontal;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float dirY;
    Rigidbody2D rb;

    //facing
    private bool facingRight = true;
    private SpriteRenderer sr;

    //Animate
    public Animator animator;

    //Weapon
    public SpriteRenderer weapon;
    public Collider2D weaponCollider;
    private bool hammertime = false;


    public bool ClimbingAllowed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Jump") && IsGrounded() == true && extraJumps > 0 ) // Jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            
            extraJumps--;
        }

     

        if (Input.GetButtonDown("Jump") && IsGrounded() == false && extraJumps > 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            extraJumps--;
        }

          if(Input.GetButtonUp("Jump")) //Jump cut
        {
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCut);
            }
        }

        if(IsGrounded() == true)
        {
            extraJumps = extraJumpsValue;
            animator.SetBool("IsGrounded", true);
        }

        if (IsGrounded() == false)
        {
            
            animator.SetBool("IsGrounded", false);
        }

        coyoteRemember -= Time.deltaTime;
        if (IsGrounded())
        {
            coyoteRemember = coyoteTime;
        }

        jumpStorage -= Time.deltaTime;
        if(Input.GetButtonDown("Jump"))
        {
            jumpStorage = jumpStorageTime;
        }

        if((jumpStorage > 0) && (coyoteRemember > 0))
        {
            jumpStorage = 0;
            coyoteRemember = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (ClimbingAllowed) // Climbing
        {
     
            dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
            
        }

        horizontal = Input.GetAxisRaw("Horizontal"); //Movement
        //Debug.Log(horizontal);
        //Move right
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            //sr.flipX = false;
            //Debug.Log("R");
            animator.SetBool("IsMoving", true);
            rb.AddForce(new Vector2(moveSpeed, 0));
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {

            //Move left
            //sr.flipX = true;
            //Debug.Log("L");
            rb.AddForce(new Vector2(-moveSpeed, 0));
            animator.SetBool("IsMoving", true);
        }
        else
        {
            //Debug.Log("IDLE");
            animator.SetBool("IsMoving", false);
        }
        Flip();
        
    }
    

    private void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            facingRight = !facingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y); //Baisc Movement
     
        if (ClimbingAllowed) //Climbing
        {
            animator.SetBool("IsClimbing", true);
            rb.isKinematic = true;
            rb.velocity = new Vector2(horizontal * moveSpeed, dirY);           
        }
        else
        {
            animator.SetBool("IsClimbing", false);
            rb.isKinematic = false;
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);         
        }
    }

    public bool IsGrounded()
    {
        bool grounded = Physics2D.BoxCast(transform.position + new Vector3(0f, 0f, 0f), new Vector3(0.1f, 0.7f, 0f), 0, Vector2.down, 0.7f, ground);
        
        return grounded;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Hammer")
        {
            weapon.enabled = true;
            weaponCollider.enabled = true;
            hammertime = true;
            StartCoroutine(rampage());
        }
        
    }

    IEnumerator rampage()
    {
        yield return new WaitForSeconds(6);
        weapon.enabled = false;
        weaponCollider.enabled = false;
        hammertime = false;
    }
}
