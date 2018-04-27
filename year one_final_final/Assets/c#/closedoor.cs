using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedoor : MonoBehaviour {
    public GameObject door;
    door de;
    int num;
	// Use this for initialization
	void Start () {
        de = door.gameObject.GetComponent<door>();
        num = 0;
	}
    void Update()
    {
        if (num == 2)
        {
            de.po = true;
            num = 3;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") )
        {

            num += 1;
            
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            num -= 1;

        }
    }
}
