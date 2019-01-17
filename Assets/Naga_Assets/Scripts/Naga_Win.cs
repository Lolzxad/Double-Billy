using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Naga_Win : MonoBehaviour {

    public GameObject endMenu;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider win)
    {
        if (win.gameObject.tag == "Player")
        {
            endMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
