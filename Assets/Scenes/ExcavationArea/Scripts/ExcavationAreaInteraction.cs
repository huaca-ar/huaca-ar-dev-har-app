using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcavationAreaInteraction : MonoBehaviour {

	public Transform staminaBar;
	public Slider staminaBarSlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown() {
		staminaBarSlider.value += 0.2f;
		Debug.Log("Zona de excavacion tocada");
		Animator animator = gameObject.GetComponent<Animator>();
		animator.SetBool("dig", true);
	}
}
