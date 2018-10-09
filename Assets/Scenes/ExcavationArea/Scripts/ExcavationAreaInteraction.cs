using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcavationAreaInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown() {
		Debug.Log("Zona de excavacion tocada");
		Animator animator = gameObject.GetComponent<Animator>();
		animator.SetBool("dig", true);
	}
}
