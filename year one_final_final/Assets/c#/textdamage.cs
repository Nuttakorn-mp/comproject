using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textdamage : MonoBehaviour {

    int dam;
    public GameObject gun;
    Player_Shooting gunn;
    throwbomb bomb;
    Text text;


    void Awake()
    {
        text = GetComponent<Text>();
        gunn = gun.gameObject.GetComponent<Player_Shooting>();
        bomb = gun.gameObject.GetComponent<throwbomb>();
    }


    void Update()
    {
        dam = gunn.damagePerShot;
        text.text = "Damage : "+dam + " bomb : " +bomb.hasgrenade;
    }
}