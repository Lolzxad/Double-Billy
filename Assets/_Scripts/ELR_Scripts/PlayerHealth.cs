using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int playerHP = 50;
    Renderer p_Renderer;

	// Use this for initialization
	void Start () {
        p_Renderer = GetComponent<Renderer>();
	}
}
