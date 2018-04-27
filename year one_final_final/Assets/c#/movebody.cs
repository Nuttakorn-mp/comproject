using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebody : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 50 * Time.deltaTime);
    }
}
