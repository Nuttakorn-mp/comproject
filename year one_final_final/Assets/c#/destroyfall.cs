using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyfall : MonoBehaviour {
    HP hpp;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hpp = col.gameObject.GetComponent<HP>();
            if (hpp != null)
            {
                hpp.hp = 0;
            }
            
        }
        else
        {
            Destroy(col.gameObject);
        }
        
    }
    void Update () {
		
	}
}
