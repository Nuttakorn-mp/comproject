using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class zombie : MonoBehaviour {
    GameObject[] play;
    Animator anim;
    //Transform play;
    private NavMeshAgent nav;
    bool ao;
    float timer;
    public int attake =10;
    public int slowa;
    HP cc;
    float Distance1;
    float Distance2;
    public float bet = 1f;
    public bool explodzombie;
    public float radius = 5f;
    public bool posion;
    public float timeslow = 2;
    public int force_ = 700;
    moveplayer movep;
    public GameObject Dieexp;
    // Use this for initialization
    void Start () {
        play = GameObject.FindGameObjectsWithTag("Player");
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        ao = false;
        Distance1 = Vector3.Distance(gameObject.transform.position, play[0].transform.position);
        Distance2 = Vector3.Distance(gameObject.transform.position, play[1].transform.position);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("friends"))
        {
            
            ao = true;
            cc = col.gameObject.GetComponent<HP>();
            movep = col.gameObject.GetComponent<moveplayer>();
            if (anim != null)
            {

                anim.SetBool("loled", ao);
            }



        }
    }
    void OnCollisionExit(Collision col)
    {
        ao = false;
        if (anim != null)
        {

            anim.SetBool("loled", ao);
        }
    }
    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (play == null)
        {
                return;
            
        }
        
        if (Distance1 > Distance2)
        {
            nav.SetDestination(play[1].transform.position);
        }
        else
        {

            nav.SetDestination(play[0].transform.position);
        }
        
        timer += Time.deltaTime;
        
        if ( timer > bet && ao == true)
        {
            Attack();
        }
    }
    void Attack()
    {

       
        if (cc.hp > 0) ;
        {
            timer = 0f;
            cc.takedamge(attake);
        }
        if (posion == true)
        {
            movep.slow(slowa, timeslow);
        }
        if (explodzombie == true)
        {
            Instantiate(Dieexp,transform.position,transform.rotation );
            explode();
            Destroy(gameObject);
        }
        


    }
    void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force_, transform.position, radius);
            }
        }
    }

}

