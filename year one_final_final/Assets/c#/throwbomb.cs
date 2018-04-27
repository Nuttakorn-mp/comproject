using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwbomb : MonoBehaviour {
    public int hasgrenade;
    public float ThrowForce = 40f;
    public GameObject bomb;
    public int numplay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (numplay == 1)
        {
            if (Input.GetMouseButtonDown(1) & hasgrenade > 0)
            {
                Throwgrenade();
                hasgrenade -= 1;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.H) & hasgrenade > 0)
            {
                Throwgrenade();
                hasgrenade -= 1;
            }
        }
	}
    public void moregrenade(int a)
    {
        hasgrenade += a;
    }
    void Throwgrenade()
    {
        GameObject grenade = Instantiate(bomb, transform.position, transform.rotation);
        Rigidbody r = grenade.GetComponent<Rigidbody>();
        r.AddForce(transform.forward * ThrowForce, ForceMode.VelocityChange);
    }
}
