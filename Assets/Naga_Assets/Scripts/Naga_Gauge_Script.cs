using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Naga_Gauge_Script : MonoBehaviour
{
    [SerializeField]
    private Image gaugeHP;
    [SerializeField]
    private Image gaugeLight;
    [SerializeField]
    private Image gaugeExp;

    private float percentHP;
    private float percentLight;
    private float percentExp;

    void Start ()
    {
        percentHP = 1F;
        percentLight = 1F;
        percentExp = 0F;
    }
	
	void Update ()
    {
        percentHP = GameObject.Find("Player").GetComponent<Naga_Player_Stats>().percentHP;
        percentLight = GameObject.Find("Player").GetComponent<Naga_Player_Stats>().percentLight;
        percentExp = GameObject.Find("Player").GetComponent<Naga_Player_Stats>().percentExp;
        gaugeHP.fillAmount = percentHP;
        gaugeLight.fillAmount = percentLight;
        gaugeExp.fillAmount = percentExp;
    }
}
