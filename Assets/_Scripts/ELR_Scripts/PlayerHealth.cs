using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int playerHP = 100;
    Renderer p_Renderer;

	// Use this for initialization
	void Start () {
        p_Renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(playerHP <= 50)
        {
            p_Renderer.material.color = Color.red;
        }
        if(playerHP <= 0)
        {
            p_Renderer.material.color = Color.black;
            playerHP = 0;
        }
        
		
	}
}
