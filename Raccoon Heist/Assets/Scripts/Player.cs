using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public static Player instance { get; private set; }
    bool startJump, endJump;
    [Header("Gameplay Values")]
    public float Speed = 5;
    public float Gravity = 9.8f;
    public float FallMultiplier = 2;
    public float JumpHeight = 1;
    public float FeetWidth = 1;
    public float GroundTestLength = 0.1f;

    [HideInInspector]
    public bool IsJumping;
    [HideInInspector]
    public bool IsGrounded;

    Rigidbody2D rb;
    Transform feet;
    float HorizontalInput;
    bool active = true;
    Animator anim;
    SpriteRenderer sr;
    float AnimHorizontalInput = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        feet = transform.Find("Feet");
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {   
        if(active){
            if (Input.GetButtonDown("Jump")) Jump();
            if (Input.GetButtonUp("Jump")) ReleaseJump();

            HorizontalInput = Input.GetAxisRaw("Horizontal");
            UpdateAnimationState();
        }
    }

    public bool change(){
        active = !active;
        anim.SetBool("IsChosen", active);
        ReleaseJump();
        return active;
    }

    public void change(bool mode){
        active = mode;
        anim.SetBool("IsChosen", mode);
        ReleaseJump();
    }

    void UpdateAnimationState()
    {
        anim.SetBool("IsRunning", HorizontalInput != 0);
        if (HorizontalInput != 0)
        {
            AnimHorizontalInput = HorizontalInput;
        }
        sr.flipX = AnimHorizontalInput <= 0;
    }

    void FixedUpdate() 
    {
        JumpPhysics();

        if(active){
            rb.velocity = new Vector2(HorizontalInput * Speed, rb.velocity.y);
        
        }else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void Jump()
    {
        startJump = true;
    }

    public void ReleaseJump()
    {
        endJump = true;
    }

    private void JumpPhysics()
    {   

        IsGrounded = Physics2D.BoxCast(feet.position, new Vector2(FeetWidth, 0.001f), 0,
                    Gravity > 0 ? Vector2.down : Vector2.up, GroundTestLength, LayerMask.GetMask("Ground")) ||
                    Physics2D.BoxCast(feet.position, new Vector2(FeetWidth, 0.001f), 0,
                    Gravity > 0 ? Vector2.down : Vector2.up, GroundTestLength, LayerMask.GetMask("Player"));

        if (IsGrounded && startJump)
        {
            transform.Find("Jump").GetComponent<AudioSource>().Play();
            startJump = false;
            IsJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(Gravity) * Mathf.Sqrt(JumpHeight * 2 * Mathf.Abs(Gravity)));
        }

        if (endJump && IsJumping)
        {
            endJump = false;
            IsJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (rb.velocity.y > 0 && Gravity > 0 || rb.velocity.y < 0 && Gravity < 0)
        {
            rb.velocity += Vector2.down * Gravity * Time.fixedDeltaTime;
        }
        else
        {
            IsJumping = false;
            rb.velocity += Vector2.down * Gravity * FallMultiplier * Time.fixedDeltaTime;
        }

        endJump = startJump = false;
    }
}
