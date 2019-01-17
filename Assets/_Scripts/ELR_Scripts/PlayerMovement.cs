using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float gravity = -10f;
    float playerSpeed = 5f;

    Animator anim;
    Rigidbody rb;
    SpriteRenderer spr;
    public Collider checkGround;
    private bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        anim = GetComponent<Animator> ();
        spr = GetComponent<SpriteRenderer> ();
        checkGround = GetComponent<Collider> ();
   
    }

    // Update is called once per frame
    void FixedUpdate () {
       
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 translation = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(translation);

        if (checkGround == true)
        {
            anim.SetBool ("isGrounded", true);

        }
        else
        {
            anim.SetBool("isGrounded", false);
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

}
