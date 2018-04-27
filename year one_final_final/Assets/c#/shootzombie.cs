using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class shootzombie : MonoBehaviour {
    zombieH hp;
    Transform me;
    bool shoot;
    float timer;
    public int speedshoot;
    GameObject player;
    public List<GameObject> Monster;
    public float Distance;
    Quaternion newRotation;
    Animator anim;
    Rigidbody r;
	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        me = GetComponent<Transform>();
        shoot = false;
        hp = GetComponent<zombieH>();
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return;
        }
        Distance = Vector3.Distance(gameObject.transform.position,player.transform.position);
        if (Distance > 6)
        {
            shoot = false;
        }
        else
        {

            shoot = true;
        }
        if (anim != null)
        {
            anim.SetBool("atta", shoot);
         }
        timer += Time.deltaTime;
        if (shoot== true && timer > speedshoot && hp.currentHealth>0)
        {
            Vector3 playerToMouse = player.transform.position - transform.position;
            playerToMouse.y = 0f;
            newRotation = Quaternion.LookRotation(playerToMouse);
            r.MoveRotation(newRotation);
            spawzombie();

            timer = 0;
        }
        
	}
    
    void spawzombie()
    {
        
        int spawnPointIndex = Random.Range(0, Monster.Count);
        Instantiate(Monster[spawnPointIndex], gameObject.transform.position, gameObject.transform.rotation);
    }
}
