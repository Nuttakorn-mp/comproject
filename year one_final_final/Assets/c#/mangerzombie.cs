using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mangerzombie : MonoBehaviour
{

    GameObject[] playerHealth;
    HP heart1;
    HP heart2;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public bool onespawn;
    int num;

    void Start()
    {
        num = 0;
        playerHealth = GameObject.FindGameObjectsWithTag("Player");
        
        if (onespawn)
        {
            
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            ArrayList arr = new ArrayList(spawnPoints);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        else
        {
            ;
            InvokeRepeating("Spawn", spawnTime, spawnTime);
            ArrayList arr = new ArrayList(spawnPoints);
        }
    }

    void Spawn()

    {
        foreach (GameObject player in playerHealth)
        {
            HP rb = player.GetComponent<HP>();
            if(rb != null)
            if (rb.hp < 0)
            {
                num += 1;
            }
        }
        if (num >= 2)
        {
            return;
        }

        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        if (spawnPoints[spawnPointIndex] != null)
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            
        }
        else 
        {
            Destroy(spawnPoints[spawnPointIndex]);
            
        }

     
    }
    
}
