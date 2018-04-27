using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    moveplayer movep;
    public int maxhp;
    public int hp;
    public Slider mon;
    float timer;
    float starttimer;
    public int regen;
    GameObject player;
    public GameObject hat;
    public GameObject bod;
    public GameObject[] gun;
    // Use this for initialization
    void Start()
    {
        movep = GetComponent<moveplayer>();
        mon.maxValue = hp;
        mon.value = hp;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("healer"))
        {

            regen += 5;

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("healer"))
        {

            regen -= 0;

        }
    }
    void Update()
    {
        if (hp <= 0)
        {
            gameObject.tag = "Die";  
        }
        if (gameObject.tag== "Die")
        {
            movebody die = GetComponent<movebody>();
            moveplayer clo = GetComponent<moveplayer>();
            BoxCollider bo = GetComponent<BoxCollider>();
            Rigidbody r = GetComponent<Rigidbody>();
            r.useGravity = false;
            clo.enabled = false;
            bo.enabled = false;
            hat.SetActive(false);
            bod.SetActive(false);
            gun[0].SetActive(false);
            gun[1].SetActive(false);
            die.enabled = true;
            
            
        }
        removeskill();
        hp += regen;
        mon.value = hp;
        if (hp > maxhp)
        {
            hp = maxhp;
        }

    }
    public void takedamge(int dam)
    {
        hp = hp - dam;
        mon.value = hp;
        if (hp <= 0)
        {
            regen = 0;
            player = GameObject.FindGameObjectWithTag("Player");
            gameObject.tag = "Die";
            //gameObject.SetActive(false);
            
        }

    }
    public void moreHP(int heal, float timeskill)
    {
        regen = heal;
        timer = timeskill;
        starttimer = timer;
    }
    public void removeskill()
    {

        if (timer > 0 && regen != 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                regen = 0;
                timer = starttimer;
            }

        }
    }
}
