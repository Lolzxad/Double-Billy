using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Naga_Dialog : MonoBehaviour {

    //Variables
    public GameObject dialogUI;
    public GameObject dialogTxt;
    private int txtHierarchy = 0;
    private GameObject pNJ_Canvas;

    void Start()
    {
        pNJ_Canvas = this.gameObject.GetComponent<Naga_Button_Interact>().pNJ_Canvas;
    }


    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown("a"))
        {
            //Mettre une fonction pour bloquer le déplacement sans arrêter le temps de jeu (sinon la couroutine ne marche pas)
            pNJ_Canvas.SetActive(false);
            txtHierarchy = 0;
            dialogUI.SetActive(true);
            dialogTxt.GetComponent<Text>().text = "Insérez du texte ici :3";
            StartCoroutine(txtprogress());
        }

        if (txtHierarchy == 1 && Input.GetButtonDown("Submit"))
        {
            dialogTxt.GetComponent<Text>().text = "Insérez le second texte ici :3";
            StartCoroutine(txtprogress());
        }

        if (txtHierarchy == 2 && Input.GetButtonDown("Submit"))
        {
            txtHierarchy++;
            End();
        }

    }

    void End()
    {
        pNJ_Canvas.SetActive(true);
        txtHierarchy = 0;
        dialogUI.SetActive(false);
    }

    IEnumerator txtprogress()
    {
        yield return new WaitForSeconds(0.1f);
        txtHierarchy++;
        Debug.Log(txtHierarchy);
    }
}
