using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class control_cermera : MonoBehaviour {
    public enum RotationAxis{
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxis axe = RotationAxis.MouseY;
    public RotationAxis axes = RotationAxis.MouseX;
    public float senx = 10f;
    public float seny = 10f;
    public float _rotationX = 0 ;
	public float min = -45.0f;
    public float minx = 45.0f;
	
	
	// Update is called once per frame
	void Update () {
        if (axes == RotationAxis.MouseX){
            transform.Rotate(0,Input.GetAxis("Mouse X")*senx,0);

        } else if (axes == RotationAxis.MouseY){
            _rotationX -= Input.GetAxis("Mouse Y")*seny;
            _rotationX = Mathf.Clamp(_rotationX,min,minx);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3 (_rotationX,rotationY,0);  
        }
        if (axe == RotationAxis.MouseX){
            transform.Rotate(0,Input.GetAxis("Mouse X")*senx,0);

        } else if (axe == RotationAxis.MouseY){
            _rotationX -= Input.GetAxis("Mouse Y")*seny;
            _rotationX = Mathf.Clamp(_rotationX,min,minx);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3 (_rotationX,rotationY,0);  
        }
    }
}