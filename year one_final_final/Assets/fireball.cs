using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    float timer_;
    Transform play;
    Rigidbody r;
    HP cc;
    public int Dam;
    public GameObject exp;
	// Use this for initialization
	void Start () {
        timer_ = 5;
        play = GameObject.FindGameObjectWithTag("Player").transform;
        r = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        timer_ -= Time.deltaTime;
        if (timer_ < 0)
        {
            Destroy(gameObject);
        }
        r.velocity = transform.forward*10;

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            cc = col.gameObject.GetComponent<HP>();
            if (cc != null)
            {
                cc.takedamge(Dam);
                Destroy(gameObject);
                Instantiate(exp, gameObject.transform.position, gameObject.transform.rotation);
            }
            
            



        }
    }
}
