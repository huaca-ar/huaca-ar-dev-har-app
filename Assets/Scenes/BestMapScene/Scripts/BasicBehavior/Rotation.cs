using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public Transform playerTransform;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;


    public bool rotateAroundPlayer = true;

    public float rotationsSpeed = 4.0f;

	// Use this for initialization
	void Start () {
        cameraOffset = transform.position - playerTransform.position;	
	}
	
	// LateUpdate is called after Update methods
	void LateUpdate () {

		//hay que cambiar el if para que gire solo cuando se haya hecho un swipe

        if(rotateAroundPlayer)
        {
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationsSpeed, Vector3.up);
				// aca hay que cambiar 

            cameraOffset = camTurnAngle * cameraOffset;
        }
		// hasta aca


        Vector3 newPos = playerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        transform.LookAt(playerTransform);
	}
}
