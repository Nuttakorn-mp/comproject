using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemtwo : MonoBehaviour {
    moveplayer skill;
    public int morespeed = 2;
    public int damage = 5;
    public int moregreande = 5;
    HP heart;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 360, 0) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int num = Random.Range(0, 3);
            
            skill = other.gameObject.GetComponent<moveplayer>();
            

            if (num == 2)
            {
                skill.moreda += damage;
                
            }

            else if (num == 1)
            {
                skill.startspeed += morespeed;
                skill.speed += morespeed;
            }
            else if (num == 0)
            {
                hashbomb th = other.gameObject.GetComponent<hashbomb>();

                th.hasgrend(moregreande);
                
                
            }
            Destroy(gameObject);
        }
        
        
    }
}
