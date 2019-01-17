using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    //Varriables
    //Vie
    [HideInInspector]
    public float percentHP;
    private float currentPercentHP;
    private int basicLifePoints = 50;
    [SerializeField]
    public float playerHP = 50;
    [SerializeField]
    private int lP = 10;
    //private int p1Score = 0;
    [SerializeField]
    public int p1Money = 10;
    public GameObject endMenu;


    // Update is called once per frame
    void Update()
    {
        GameObject.Find("LP - Text").GetComponent<Text>().text = lP.ToString();
        //GameObject.Find("P1Score - Text").GetComponent<Text>().text = p1Score.ToString();
        GameObject.Find("P1$Score - Text").GetComponent<Text>().text = p1Money.ToString();

        currentPercentHP = playerHP / basicLifePoints;

        if (currentPercentHP > 0.8f)
        {
            percentHP = 1;
        }

        else if (currentPercentHP > 0.6f && currentPercentHP <= 0.8f)
        {
            percentHP = 0.8f;
        }

        else if (currentPercentHP > 0.4f && currentPercentHP <= 0.6f)
        {
            percentHP = 0.6f;
        }

        else if (currentPercentHP > 0.2f && currentPercentHP <= 0.4f)
        {
            percentHP = 0.4f;
        }

        else if (currentPercentHP > 0 && currentPercentHP <= 0.2f)
        {
            percentHP = 0.2f;
        }

        else if (currentPercentHP <= 0)
        {
            percentHP = 0;
        }

        if (playerHP == 0 && lP > 0){
            lP--;
            playerHP = basicLifePoints;
        }

        else if (lP <= 0)
        {
            endMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }


}
