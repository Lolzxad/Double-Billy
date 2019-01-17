using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isGrounded;
    //private bool leftPlayer = false;
    //private bool rightPlayer = false;

    private IEnumerator coroutine;

    #region Initialisation enfants
    public GameObject groundCheck;
    //public GameObject leftSide;
    //public GameObject rightSide;
    public GameObject rangeGrab;
    public GameObject rangePunch;
    public GameObject rangeKick;
    private Collider groundCollider;
    //private Collider leftCollider;
    //private Collider rightCollider;
    private Collider rangeGrabCollider;
    private Collider rangePunchCollider;
    private Collider rangeKickCollider;
    #endregion

    //Stats de l'ennemi 
    [SerializeField]
    float enemyMaxHealth = 5f;
    float enemyHealth = 5f;

    //Stats de dégâts
    [SerializeField]
    float punchDamage = 1f;
    [SerializeField]
    float kickDamage = 2f;
    [SerializeField]
    float grabDamage = 3f;

    [SerializeField]
    float punchKnockbackTime = 0.2f;
    [SerializeField]
    float kickKnockbackTime = 0.4f;
    [SerializeField]
    float grabKnockbackTime = 0.6f;


    private void Start()
    {
        enemyHealth = enemyMaxHealth;
        rb2d = GetComponent<Rigidbody2D>();
        groundCollider = groundCheck.GetComponent<Collider>();
        //leftCollider = leftSide.GetComponent<Collider>();
        //rightCollider = rightSide.GetComponent<Collider>();
        rangeGrabCollider = rangeGrab.GetComponent<Collider>();
        rangePunchCollider = rangePunch.GetComponent<Collider>();
        rangeKickCollider = rangeKick.GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other, string punchKickGrab)
    {
        if (other.tag == "Player")
        {
            print("i    qbwciqbviqlevf");
        }
        if ((punchKickGrab == "punch" || punchKickGrab == "punch2") && other.tag == "Player")
        {
            EnemyHealthLoss(punchDamage);
            coroutine = FreezeHP(punchKnockbackTime);
            StartCoroutine(coroutine);
        }
        else if ((punchKickGrab == "kick" || punchKickGrab == "kick2") && other.tag == "Player")
        {
            EnemyHealthLoss(kickDamage);
            coroutine = FreezeHP(kickKnockbackTime);
            StartCoroutine(coroutine);
        }
        else if ((punchKickGrab == "grab" || punchKickGrab == "grab2") && other.tag == "Player")
        {
            EnemyHealthLoss(grabDamage);
            coroutine = FreezeHP(grabKnockbackTime);
            StartCoroutine(coroutine);
        }
    }

    public void EnemyHealthLoss(float hitReceived)
    {
        enemyHealth -= hitReceived;

        //si la vie arrive à 0, l'ennemi meurt (dans la console pour l'instant)          ramener animation de mort
        if (enemyHealth <= 0)
        {
            //empêche de passer trop loin sous 0 pour les tests
            enemyHealth = 0;

            //fédétruc de quand on est mort
        }
    }

    public IEnumerator FreezeHP(float temps)
    {
        float currentHealth = enemyHealth;
        for (float t = temps; t > 0; t -= Time.deltaTime)
        {
            enemyHealth = currentHealth;
            yield return new WaitForFixedUpdate();
        }
    }
}