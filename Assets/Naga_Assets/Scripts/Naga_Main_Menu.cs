using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Naga_Main_Menu : MonoBehaviour
{
    [SerializeField]
    private int play;
    [SerializeField]
    private int option;

    public GameObject quitMenu;
    [SerializeField]
    private GameObject firstButton;
    [SerializeField]
    private GameObject firstQuitMenuButton;
    public EventSystem eS;
    private GameObject storeSelected;


    void Start()
    {
        storeSelected = firstButton;
    }

    void Update()
    {
        if (eS.currentSelectedGameObject != storeSelected)
        {
            if (eS.currentSelectedGameObject == null)
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

        if (!quitMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Cancel"))
            {
                quitMenu.SetActive(true);
                eS.SetSelectedGameObject(firstQuitMenuButton);
            }

        }

        else if (quitMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Cancel"))
            {
                quitMenu.SetActive(false);
                eS.SetSelectedGameObject(firstButton);
            }

        }
    }

    public void Play()
    {
        SceneManager.LoadScene(play);
    }

    public void Option()
    {
        SceneManager.LoadScene(option);
    }

    public void Quit()
    {
        quitMenu.SetActive(true);
        eS.SetSelectedGameObject(firstQuitMenuButton);
    }

    public void QuitYes()
    {
        Debug.Log("Le jeu se ferme");
        Application.Quit();
    }

    public void QuitNo()
    {
        quitMenu.SetActive(false);
        eS.SetSelectedGameObject(firstButton);
    }

}
