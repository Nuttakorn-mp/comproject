using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
    public bool po;
    BoxCollider box;
    MeshRenderer me;
	// Use this for initialization
	void Start () {
        me = GetComponent<MeshRenderer>();
        box = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(po == true)
        {
            me.enabled = true;
            box.enabled = true;
        }
        if (po == false)
        {
            me.enabled = false;
            box.enabled = false;
        }
    }
}
