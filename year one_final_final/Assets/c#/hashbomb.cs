using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hashbomb : MonoBehaviour {
    public GameObject gun;
    
    throwbomb bomb;
    
    // Use this for initialization
    void Start () {

         bomb   = gun.gameObject.GetComponent<throwbomb>();
	}
	
	// Update is called once per frame
	void Update () {
        

    }
    public void hasgrend(int a)
    {
        bomb.moregrenade(a);
    }
}
