using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [SerializeField]
    public float movementSpeed;
    public float jumpHigh;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private bool airControl;

    private Animator myAnimator;

    private Vector2 startPos;

    private Rigidbody2D myRigidbody;

    private bool jump;

    private bool attack;

    private bool jumpAttack;

    private bool slide;

    private bool grounded;

    private float groundRadius = .2f;

    private bool facingRight = true;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        startPos = transform.position;

    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        grounded = IsGrounded();

        Flip(horizontal);

        HandleMovement(horizontal);

        
        HandleAttacks();

        
        HandleLayers();

        
        ResetActions();
    }

 
    private void HandleMovement(float horizontal)
    {

        
        if (myRigidbody.velocity.y < 0) 
        {
            myAnimator.SetBool("Land", true); 
        }
        if (!myAnimator.GetBool("Slide") && grounded && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") || airControl) 
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); 
        }
        if (grounded && jump) 
        {
            grounded = false;
			myAnimator.SetBool("jump", true);
            myRigidbody.AddForce(new Vector2(0f, jumpHigh));


        }
        if (grounded && slide && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide")) 
        {
            myAnimator.SetBool("Slide", true); 
        }
        else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide")) 
        {
            myAnimator.SetBool("Slide", false); 
        }

        
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (transform.position.y <= -10) 
        {
            transform.position = startPos;
            myRigidbody.velocity = Vector2.zero;
        }
    }

  
    private void HandleAttacks()
    {
       
        if (attack && grounded && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myAnimator.SetTrigger("Attack"); 

            myRigidbody.velocity = Vector2.zero; 
        }
        
        if (jumpAttack && !grounded && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("JumpAttack"))
        {
            myAnimator.SetBool("JumpAttack", true); 
        }
        
        if (!jumpAttack && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("JumpAttack"))
        {   
           
            myAnimator.SetBool("JumpAttack", false);
        }
    }

 
    private bool IsGrounded()
    {
        
        if (myRigidbody.velocity.y <= 0)
        {
            
            foreach (Transform point in groundPoints)
            {
                
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) 
                    {
                        myAnimator.SetBool("Land", false); 
                        return true;
                    }
                }
            }
        }


        return false; 
    }

    private void Flip(float horizontal)
    {
        
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            
            facingRight = !facingRight;

            
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

   
    private void HandleLayers()
    {

        
        if (!IsGrounded())
        {   
            
            myAnimator.SetLayerWeight(1, 1);
        }
        else 
        {
            
            myAnimator.SetLayerWeight(1, 0);
        }
    }

 
    private void ResetActions()
    {
        jump = false;
        jumpAttack = false;
        attack = false;
        slide = false;
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
			
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true;
            jumpAttack = true;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            slide = true;
        }
    }
}
