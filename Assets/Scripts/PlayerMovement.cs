using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2=UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; 
    BoxCollider2D col;
    Animator anim;
    SpriteRenderer sprite;
    float dirX;
    [SerializeField]private float moveSpeed=7;
    [SerializeField]private float jumpForce=14;
    [SerializeField]private LayerMask jumpableGround;

    private enum MovementState {idle,run,jump,fall} ;
    
    [SerializeField] private AudioSource jumpEffect;
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        col=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX=Input.GetAxisRaw("Horizontal");
        
        rb.velocity=new Vector2(dirX*moveSpeed,rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGrounded()==true )
        {

            jumpEffect.Play();
            rb.velocity=new Vector2(rb.velocity.x,jumpForce);
            
        }
        UpdateAnimation();
        
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if(dirX>0)
        {
            state=MovementState.run; 
            sprite.flipX=false;
        }
        else if(dirX<0)
        {
            state=MovementState.run;
            sprite.flipX=true;
        }
        else
        {
            state=MovementState.idle;
        }
        if(rb.velocity.y>.1f)
        {
            state=MovementState.jump;
        }
        else if(rb.velocity.y<-.1f)
        {
            state=MovementState.fall;
        }


        anim.SetInteger("state",(int)state);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center,col.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }

    
}
