using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecamera : MonoBehaviour {
    public Transform target;
    Vector3 offset ;
	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            return;
        }
		transform.position = target.position + offset;
	}
}
