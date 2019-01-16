using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Naga_Player_Stats : MonoBehaviour
{

    //Varriables
    //Vie
    [HideInInspector]
    public float percentHP;
    private int basicLifePoints = 100;
    [SerializeField]
    private float currentLife;

    //Light
    [HideInInspector]
    public float percentLight;
    private int LightMax = 50;
    [SerializeField]
    private float currentLight;

    //Exp
    [HideInInspector]
    public float percentExp;
    private int expMax = 2000;
    [SerializeField]
    private float currentExp = 0;
    public string lvl;


    // Use this for initialization
    void Start ()
    {
        currentLife = basicLifePoints;
        currentLight = LightMax;
        lvl = "1";
        GameObject.Find("Level - Text").GetComponent<Text>().text = lvl;
    }
	
	// Update is called once per frame
	void Update ()
    {
        percentHP = currentLife / basicLifePoints;
        percentLight = currentLight / LightMax;
        percentExp = currentExp / expMax;
    }
}
