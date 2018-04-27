using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour {
    
    moveplayer skill;
    float radius = 5f;
    public int force_ = 700;
    float timeskill = 5f;
    public int morespeed = 10;
    //public int damage = 50;
    public int heal = 10;
    HP heart;
    public float speeddamage = 0.1f;
    
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
            int num = Random.Range(0,4);
            
            skill = other.gameObject.GetComponent<moveplayer>();
            if (num == 3)
            {
                heart = other.gameObject.GetComponent<HP>();
                heart.moreHP(heal, timeskill*2);
            }
            
            if (num == 2)
            {
                //int su = skill.startda*2 ;
                skill.moredamge((skill.startda + skill.moreda) * 2, timeskill*2);
            }
            
            else if (num == 1)
            {
                skill.morespeeddamge(speeddamage, timeskill);
                skill.speedt(morespeed, timeskill);
            } else if (num == 0) {
                hashbomb th = other.gameObject.GetComponent<hashbomb>();
                
                th.hasgrend(1);
            }
            Destroy(gameObject);
        }
        
    }
    void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force_, transform.position, radius);
            }
        }
    }
    
}
