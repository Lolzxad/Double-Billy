using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naga_Button_Interact : MonoBehaviour {

    //Variables
    private bool bPlayerCloser;
    public GameObject pNJ_Canvas;

    private void OnTriggerEnter2D(Collider2D closeZone)
    {
        if (closeZone.gameObject.tag == "Player")
        {
            bPlayerCloser = true;
            pNJ_Canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D nocloseZone)
    {
        if (nocloseZone.gameObject.tag == "Player")
        {
            bPlayerCloser = false;
            pNJ_Canvas.SetActive(false);
        }
    }
}
