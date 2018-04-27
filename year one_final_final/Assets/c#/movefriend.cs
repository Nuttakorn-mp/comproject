using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class movefriend : MonoBehaviour {
    Rigidbody r;
    public Transform host;
    public float nearbyDistance;
    public int speed;
    bool skill;
    float timer = 3;
    int startspeed;
    float starttimer;
    Transform enemy;
    void Start () {
        
        startspeed = speed;
        r = GetComponent<Rigidbody>();
        skill = false;
	}

    // Update is called once per frame
    void Update() {
        if ( host == null)
        {
            return;
        }
        enemy = GameObject.FindGameObjectWithTag("enemy").transform;
        
        Vector3 playerToMouse = enemy.position - transform.position;

        playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        r.MoveRotation(newRotation);
        if (skill)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Removeskill();
                skill = false;
                timer = starttimer;
            }

        }
        if (Vector3.Distance(transform.position, host.transform.position)>nearbyDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, host.position, speed * Time.deltaTime);
        }

    }
    public void speedt(int s,float s_time)
    {
        speed = speed + s;
        timer = s_time;
        skill = true;
        starttimer = timer;
    }
    void Removeskill()
    {
        if (speed != startspeed)
        {
            speed = startspeed;
            
        }
    }
}
