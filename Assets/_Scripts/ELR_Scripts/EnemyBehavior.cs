using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    Transform target;
    GameObject thePlayer;
    PlayerHealth playerHealth;
    Animator anim;
    float speed = 2f;
    bool follow = true;
    bool canHit = true;
    bool stopped = false;
    int Attack;
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    int moveTreeHash = Animator.StringToHash("Base Layer.MoveTree");

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerHealth = thePlayer.GetComponent<PlayerHealth>();
        AttackChoose();
        MusicSource.clip = MusicClip;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float step = speed * Time.deltaTime;

        if (follow)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            anim.SetTrigger("Move");
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
                    StartCoroutine(Hit(2));
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
                    StartCoroutine(Hit(1));
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
                    StartCoroutine(Hit(3));
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
        MusicSource.Play();
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("Damage", false);
        canHit = true;
        AttackChoose();
    }

    void AttackChoose()
    {
        Attack = Random.Range(1, 4);
        Debug.Log(Attack);
    }
}
