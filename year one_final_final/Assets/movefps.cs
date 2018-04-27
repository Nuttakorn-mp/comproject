using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefps : MonoBehaviour {
    public int speed=10;
    private CharacterController chr;
    // Use this for initialization
    void Start () {
        chr = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        chr.Move(movement);
    }
}
