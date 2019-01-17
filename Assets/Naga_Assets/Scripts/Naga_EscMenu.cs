using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Naga_EscMenu : MonoBehaviour
{

    //Variables
    public GameObject restartMenu;
    public GameObject escapeMenu;

    void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!escapeMenu.activeInHierarchy && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().endMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Menu"))
            {
                escapeMenu.SetActive(true);
                Time.timeScale = 0;
            }

        }

        else if(escapeMenu.activeInHierarchy && !restartMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Menu") || Input.GetButtonDown("Cancel"))
            {
                restartMenu.SetActive(false);
                escapeMenu.SetActive(false);
                Time.timeScale = 1;
            }

        }
    }

}
