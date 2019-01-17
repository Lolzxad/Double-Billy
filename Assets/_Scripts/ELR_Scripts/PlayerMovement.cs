﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float playerSpeed = 5f;
    private float positionz;
    private float currentpositionz;

    private void Start()
    {
        positionz = this.gameObject.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        gameObject.GetComponent<Rigidbody>().velocity = movement * playerSpeed;
	}
}
