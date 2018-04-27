using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyself : MonoBehaviour {
    float timer_;
	// Use this for initialization
	void Start () {
        timer_ = 3;
	}
	
	// Update is called once per frame
	void Update () {
        timer_ -= Time.deltaTime;
		if (timer_ < 0)
        {
            Destroy(gameObject);
        }
	}
}
