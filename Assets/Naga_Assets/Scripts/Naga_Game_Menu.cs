using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Naga_Game_Menu : MonoBehaviour
{
    [SerializeField]
    private int menu;
    [SerializeField]
    private int currentScene;
    [SerializeField]
    private GameObject firstButton;
    public GameObject restartMenu;
    [SerializeField]
    private GameObject noButton;

    public EventSystem eS;
    private GameObject storeSelected;


    void Start()
    {
        storeSelected = firstButton;
    }

    void Update()
    {
        if(eS.currentSelectedGameObject != storeSelected)
        {
            if(eS.currentSelectedGameObject == null)
            {
                eS.SetSelectedGameObject(storeSelected);
            }

            else
            {
                storeSelected = eS.currentSelectedGameObject;
            }
        }

        else
        {
            storeSelected = eS.firstSelectedGameObject;
        }

        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Menu")) && restartMenu.activeInHierarchy)
        {
            restartMenu.SetActive(false);
            eS.SetSelectedGameObject(firstButton);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }

    public void Reload()
    {
        restartMenu.SetActive(true);
        eS.SetSelectedGameObject(noButton);
    }

    public void ReloadYes()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void ReloadNo()
    {
        restartMenu.SetActive(false);
        eS.SetSelectedGameObject(firstButton);
    }

}
