using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
    public float delay = 5;
    float countown;
    bool hasExp= false;
    public float radius;
    public float force_;
    public GameObject Effbomb;
    public int bombdamage =40;
	// Use this for initialization
	void Start () {
        countown = delay;
	}
	
	// Update is called once per frame
	void Update () {
        countown -= Time.deltaTime;
        if (countown <=0f && !hasExp)
        {
            explode();
            hasExp = true;
        }
	}
    void explode()
    {
        Instantiate(Effbomb, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force_, transform.position, radius);
            }
            zombieH en = nearbyObject.GetComponent<zombieH>();
            if (en != null)
            {
                en.TakeDamage(bombdamage, nearbyObject.transform.position);
            }
        }
        Destroy(gameObject);
    }
}
