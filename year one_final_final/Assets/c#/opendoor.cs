using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour {
    public GameObject door;
    door de;
    // Use this for initialization
    void Start()
    {
        de = door.gameObject.GetComponent<door>();
    }
    // Update is called once per frame
    void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            de.po = false;

        }
    }
}
