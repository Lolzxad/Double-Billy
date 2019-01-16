using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image image;

    //Stats du joueur 
    [SerializeField]
    float playerMaxHealth = 300f;
    float playerHealth = 150f;
    [SerializeField]
    float playerRegenPerSec = 30f;
    [SerializeField]
    float playerIdleHealthLoss = 60f;
    [SerializeField]
    float playerHit = 100f;



    private void FixedUpdate()
    {
        //fait monter la vie :      à remplacer par "si les enchaînements se passent bien"
        if (Input.GetKey(KeyCode.Space))
        {
            playerHealth += playerRegenPerSec * Time.deltaTime;
        }

        //fait descendre la vie :       à remplacer par "si le joueur ne fait rien"
        if (!Input.anyKey)
        {
            playerHealth -= playerIdleHealthLoss * Time.deltaTime;
        }

        //le joueur se prend un coup (sur appui de  : à remplacer par "si le joueur ne fait rien")
        if (Input.GetMouseButtonDown(0))
        {
            playerHealth -= playerHit;
        }

        //empêche la vie de passer le maximum de vie
        if (playerHealth >= playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }

        //si la vie arrive à 0, le joueur meurt (dans la console pour l'instant)
        if (playerHealth <= 0)
        {
            print("T'es mort !");

            //empêche de passer trop loin sous 0 pour les tests
            playerHealth = 0;
        }

        //fait bouger le canvas en fonction de la vie
        image.fillAmount = playerHealth / playerMaxHealth;
    }

}