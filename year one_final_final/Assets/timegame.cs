using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timegame : MonoBehaviour {
    public static int timer;
    public static int min;
    public static bool eed;
    Text test;
	// Use this for initialization
	void Start () {
        timer = 0;
        min = 0;
        test = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (eed == true)
        {
            return;
        }
        timer += 1;
        if (timer >= 60)
        {
            timer = 0;
            min += 1;
        }
        test.text = "Time " + min + " : " + timer;
	}
}
