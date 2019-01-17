using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFar : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
        player = this.gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        player.transform.localScale = new Vector3 (1, 1, 1);
	}
}
