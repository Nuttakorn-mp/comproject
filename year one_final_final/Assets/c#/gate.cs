using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gate : MonoBehaviour {
    public GameObject plane;
    public bool end;
    
	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (plane != null)
            {
                plane.SetActive(true);
            }
            if (end == true)
            {
                timegame.eed = true;
            }




        }
    }
    // Update is called once per frame
    void Update () {
        
	}
}
