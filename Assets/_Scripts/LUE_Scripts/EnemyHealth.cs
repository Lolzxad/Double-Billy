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
    public GameObject rangeGrab;
    public GameObject rangePunch;
    public GameObject rangeKick;
    private Collider groundCollider;
    private Collider leftCollider;
    private Collider rightCollider;
    private Collider rangeGrabCollider;
    private Collider rangePunchCollider;
    private Collider rangeKickCollider;

    //Stats de l'ennemi 
    [SerializeField]
    float enemyMaxHealth = 100f;
    float enemyHealth = 75f;
    [SerializeField]
    float enemyHit = 100f;

    private void Start()
    {
        enemyHealth = enemyMaxHealth;
        rb2d = GetComponent<Rigidbody2D>();
        groundCollider = groundCheck.GetComponent<Collider>();
        leftCollider = leftSide.GetComponent<Collider>();
        rightCollider = rightSide.GetComponent<Collider>();
        rangeGrabCollider = rangeGrab.GetComponent<Collider>();
        rangePunchCollider = rangePunch.GetComponent<Collider>();
        rangeKickCollider = rangeKick.GetComponent<Collider>();
    }

    public void EnemyHealthLoss(float hitReceived)
    {
        enemyHealth -= hitReceived;

        //si la vie arrive à 0, l'ennemi meurt (dans la console pour l'instant)          ramener animation de mort
        if (enemyHealth <= 0)
        {
            print(this + " est mort !");

            //empêche de passer trop loin sous 0 pour les tests
            enemyHealth = 0;
        }
    }

    

}