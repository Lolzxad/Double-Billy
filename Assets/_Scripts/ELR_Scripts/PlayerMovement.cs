using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float gravity = 4f;
    float playerSpeed = 10f;

    Animator anim;
    Rigidbody rb;
    SpriteRenderer spr;
    public Collider checkGround;
    private bool isGrounded = false;
    bool bFacingRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        anim = GetComponent<Animator> ();
        spr = GetComponent<SpriteRenderer> ();
        checkGround = GetComponent<Collider> ();
   
    }

    // Update is called once per frame
    void FixedUpdate () {
       
        //Chara Controler
    
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 translation = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(translation);

        //Anim for movement
        anim.SetFloat("Velocity Y", vertical);
        if (anim.GetFloat("Velocity Y") < 0.1)
        {
            anim.SetFloat("Velocity Y", vertical * -1);

        }

        anim.SetFloat("Velocity X", horizontal);
        if (anim.GetFloat("Velocity X") < 0.1)
        {
            anim.SetFloat("Velocity X", horizontal * -1);

        }
      

        if (checkGround == true)
        {
            anim.SetBool ("isGrounded", true);

        }
        else
        {
            anim.SetBool("isGrounded", false);
        }

        if ((horizontal > 0 && !bFacingRight) || (horizontal < 0 && bFacingRight))
        {
            FlipSprite();
        }

        if (Input.GetButtonDown("punch"))
        {
            anim.SetTrigger("Punch");
            
        }

        if (Input.GetButtonDown("kick"))
        {
            anim.SetTrigger("Kick");
           
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("mdr le sol collideiieqbvmoz nvm sfmo verfr");
        }
    }

    // Flip
    void FlipSprite()
    {
        bFacingRight = !bFacingRight;
        Vector3 spriteLocalScale = transform.localScale;
        spriteLocalScale.x *= -1;
        transform.localScale = spriteLocalScale;
    }

}
