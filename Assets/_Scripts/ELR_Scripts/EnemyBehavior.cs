using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    Transform target;
    GameObject thePlayer;
    PlayerHealth playerHealth;
    float speed = 2f;
    bool follow = true;
    bool canHit = true;
    bool stopped = false;
    int Attack;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerHealth = thePlayer.GetComponent<PlayerHealth>();
        AttackChoose();
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;

        if (follow)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
	}

    void OnTriggerStay(Collider other)
    {
        if(other.name == "KickRange")
        {
            if (Attack == 1)
            {
                follow = false;
                if (canHit)
                {
                    stopped = false;
                    StartCoroutine(Hit(25));
                }
            }
        }
        if(other.name == "PunchRange")
        {
            if (Attack == 2)
            {
                follow = false;
                if (canHit)
                {
                    stopped = false;
                    StartCoroutine(Hit(50));
                }
            }
        }
        if(other.name == "GrabRange")
        {
            if (Attack == 3)
            {
                follow = false;
                if (canHit)
                {
                    stopped = false;
                    StartCoroutine(Hit(0));
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "KickRange")
        {
            if (Attack == 1)
            {
                follow = true;
                stopped = true;
            }
        }
        if (other.name == "PunchRange")
        {
            if (Attack == 2)
            {
                follow = true;
                stopped = true;
            }
        }
        if (other.name == "GrabRange")
        {
            if (Attack == 3)
            {
                follow = true;
                stopped = true;
            }
        }
    }

    IEnumerator Hit(int damage)
    {
        canHit = false;
        yield return new WaitForSeconds(1.0f);
        if (stopped)
        {
            canHit = true;
            yield break;    
        }
        playerHealth.playerHP -= damage;
        yield return new WaitForSeconds(1.0f);
        canHit = true;
        AttackChoose();
    }

    void AttackChoose()
    {
        Attack = Random.Range(1, 4);
        Debug.Log(Attack);
    }
}
