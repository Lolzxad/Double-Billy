using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float gravity = -10f;
    float playerSpeed = 5f;
<<<<<<< HEAD
    private float positionz;
    private float currentpositionz;

    private void Start()
    {
        positionz = this.gameObject.transform.position;
=======
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
    
>>>>>>> BrancheAnnexe

    }

    // Update is called once per frame
    void FixedUpdate () {
<<<<<<< HEAD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        gameObject.GetComponent<Rigidbody>().velocity = movement * playerSpeed;
=======
       
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
>>>>>>> BrancheAnnexe
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
