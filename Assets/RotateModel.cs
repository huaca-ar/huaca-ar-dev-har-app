using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour {

    float ROTATION_SPEED = 20;

    void OnMouseDrag()
    {

        Debug.Log("Rotando");
        float xRot = Input.GetAxis("Mouse X") * ROTATION_SPEED * Mathf.Deg2Rad;
        float yRot = Input.GetAxis("Mouse Y") * ROTATION_SPEED * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -xRot);
        transform.RotateAround(Vector3.right, yRot);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
