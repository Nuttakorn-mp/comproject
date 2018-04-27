using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class zombieH : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
    BoxCollider boxbodyzom;
    SphereCollider sphbodyzom;
    CapsuleCollider capbodyzom;
    zombie movepl;
    Animator anim;
    AudioSource enemyAudio;
    NavMeshAgent nav;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        boxbodyzom = GetComponent<BoxCollider>();
        sphbodyzom = GetComponent<SphereCollider>();
        capbodyzom = GetComponent<CapsuleCollider>();
        movepl = GetComponent<zombie>();
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        
        

        currentHealth = startingHealth;
    }


    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;
        if (enemyAudio != null)
        {
            enemyAudio.Play();
        }
        

        currentHealth -= amount;

        
        
        if (currentHealth <= 0)
        {
            if (boxbodyzom != null)
            {
                boxbodyzom.enabled = false;
            }
            if (sphbodyzom != null)
            {
               sphbodyzom.enabled = false;
            }
            if (capbodyzom != null)
            {
                capbodyzom.enabled = false;
            }

            if (movepl != null)
            {
                nav.enabled = false;
                movepl.enabled = false;
                
            }
            
            if (anim != null)
            {
                anim.SetTrigger("dead");
            }
            
            Destroy(gameObject, sinkSpeed);
        }
    }
}
