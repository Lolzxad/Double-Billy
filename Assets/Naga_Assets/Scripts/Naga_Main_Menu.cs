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
    private int score;
    [SerializeField]
    private int play2;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public GameObject quitMenu;
    public GameObject startMenu;
    public GameObject creditMenu;
    public GameObject buttons;
    [SerializeField]
    private GameObject firstButton;
    [SerializeField]
    private GameObject firstQuitMenuButton;
    public EventSystem eS;
    private GameObject storeSelected;


    void Start()
    {
        storeSelected = firstButton;
        MusicSource.clip = MusicClip;

        MusicSource.Play();

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

        if (startMenu.activeInHierarchy && !quitMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Cancel"))
            {
                quitMenu.SetActive(true);
                eS.SetSelectedGameObject(firstQuitMenuButton);
            }

            if (Input.GetButtonDown("Menu") || Input.GetButtonDown("Submit"))
            {
                buttons.SetActive(true);
                startMenu.SetActive(false);
                eS.SetSelectedGameObject(firstButton);
            }

        }

        else if (startMenu.activeInHierarchy && quitMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Menu"))
            {
                quitMenu.SetActive(false);
            }

        }

        else if (!startMenu.activeInHierarchy && !quitMenu.activeInHierarchy && !creditMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Cancel"))
            {
                startMenu.SetActive(true);
                buttons.SetActive(false);
            }

        }

        else if (!startMenu.activeInHierarchy && quitMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Cancel"))
            {
                quitMenu.SetActive(false);
                eS.SetSelectedGameObject(firstButton);
            }

        }

        else if (creditMenu.activeInHierarchy && Input.GetButtonDown("Cancel"))
        {
            creditMenu.SetActive(false);
            buttons.SetActive(true);
            eS.SetSelectedGameObject(firstButton);
        }


    }

    public void Play()
    {
        SceneManager.LoadScene(play);
    }

    public void Play2()
    {
        SceneManager.LoadScene(play2);
    }

    public void Score()
    {
        SceneManager.LoadScene(score);
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

    public void Credit()
    {
        creditMenu.SetActive(true);
        buttons.SetActive(false);
    }
}
