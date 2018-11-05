using System.Collections;
using System.Collections.Generic;
using Mapbox.Examples;
using UnityEngine;

public class AvatarMovement : MonoBehaviour {

	// Use this for initialization
	// este script tiene que estar unido al target
	public Transform target;

	public Animator avatarAnimator;
	public float speed = 0.5f;

	

	void Start () {

		transform.position = target.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target.position == this.transform.position){
			avatarAnimator.SetBool("IsWalking",false);
			Debug.Log("Avatar en idle");			
		}

	}

	void LateUpdate(){
		
			var distance = Vector3.Distance(transform.position, target.position);
			
			if(distance > 1.0f){
				// el avatar mira hacia la posicion del target

				Debug.Log("distancia entre target y avatar mayor a 0.1");
				GetComponent<RotateWithLocationProvider>().enabled = false;
				avatarAnimator.SetBool("IsWalking",true);
				transform.LookAt(target.position);
				transform.Translate(Vector3.forward*speed);

				// cam.transform.LookAt(transform.position);				
			}else{
				avatarAnimator.SetBool("IsWalking",false);
				GetComponent<RotateWithLocationProvider>().enabled = true;

			}
	}

	
	  

}
