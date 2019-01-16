﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Naga_EscMenu : MonoBehaviour
{
    public GameObject restartMenu;
    public GameObject escapeMenu;
    public GameObject playerUI;

    void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!escapeMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Menu"))
            {
                escapeMenu.SetActive(true);
                playerUI.SetActive(false);
                Time.timeScale = 0;
            }

        }

        else if(escapeMenu.activeInHierarchy && !restartMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Menu"))
            {
                restartMenu.SetActive(false);
                escapeMenu.SetActive(false);
                playerUI.SetActive(true);
                Time.timeScale = 1;
            }

        }
    }

}