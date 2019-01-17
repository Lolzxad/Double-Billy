using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Naga_Life_Script : MonoBehaviour
{
    [SerializeField]
    private Image gaugeHP;


    private float percentHP;


    void Start ()
    {
        percentHP = 1F;
    }
	
	void Update ()
    {
        percentHP = GameObject.Find("Player").GetComponent<PlayerHealth>().percentHP;
        gaugeHP.fillAmount = percentHP;
    }
}
