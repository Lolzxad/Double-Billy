using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isGrounded;

    //Initialisation enfants
    public GameObject groundCheck;
    public GameObject leftSide;
    public GameObject rightSide;
    private Collider2D groundCollider;
    private Collider2D leftCollider;
    private Collider2D rightCollider;

    //Stats de l'ennemi 
    [SerializeField]
    float enemyMaxHealth = 100f;
    float enemyHealth = 75f;
    [SerializeField]
    float enemyRegenPerSec = 30f;
    [SerializeField]
    float enemyIdleHealthLoss = 60f;
    [SerializeField]
    float enemyHit = 100f;

    private void Start()
    {
        enemyHealth = enemyMaxHealth;
        rb2d = GetComponent<Rigidbody2D>();
        groundCollider = groundCheck.GetComponent<Collider2D>();
        leftCollider = leftSide.GetComponent<Collider2D>();
        rightCollider = rightSide.GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        //if (groundCollider)

        //fait monter la vie :      à remplacer par "si les enchaînements se passent bien"
        if (Input.GetKey(KeyCode.Space))
        {
            enemyHealth += enemyRegenPerSec * Time.deltaTime;
        }

        //fait descendre la vie :       à remplacer par "si l'ennemi ne fait rien"
        if (!Input.anyKey)
        {
            enemyHealth -= enemyIdleHealthLoss * Time.deltaTime;
        }

        //l'ennemi se prend un coup (sur appui de  : à remplacer par "si l'ennemi ne fait rien")
        if (Input.GetMouseButtonDown(0))
        {
            enemyHealth -= enemyHit;
        }

        //empêche la vie de passer le maximum de vie
        if (enemyHealth >= enemyMaxHealth)
        {
            enemyHealth = enemyMaxHealth;
        }

        //si la vie arrive à 0, l'ennemi meurt (dans la console pour l'instant)
        if (enemyHealth <= 0)
        {
            print("T'es mort !");

            //empêche de passer trop loin sous 0 pour les tests
            enemyHealth = 0;
        }
    }

    public void EnemyHealthLoss(float hitReceived)
    {
        enemyHealth -= hitReceived;

        //rb2d.velocity=

        //si la vie arrive à 0, l'ennemi meurt (dans la console pour l'instant)          ramener animation de mort
        if (enemyHealth <= 0)
        {
            print(this + " est mort !");

            //empêche de passer trop loin sous 0 pour les tests
            enemyHealth = 0;
        }
    }

    

}