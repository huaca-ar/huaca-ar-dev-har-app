using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcavationAreaInteraction : MonoBehaviour {

	public GameObject extractionZone;
	public GameObject extractionCanvas;
	public GameObject findCanvas;
	public Transform staminaBar;
	public Slider staminaBarSlider;
	public GameObject arCamera;
	public GameObject mainCamera;
	private int touchCount;
	// Use this for initialization
	void Start () {
		touchCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown() {
		touchCount++;
		Animator animator = gameObject.GetComponent<Animator>();
		animator.SetBool("dig", true);
		// se incrementa barra de stamina
		staminaBarSlider.value += 1.0f/ExcavationAreas.REQUIRED_QUANTITY;
		Debug.Log("Zona de excavacion tocada, nivel de stamina : " + staminaBarSlider.value);
		if (touchCount >= ExcavationAreas.REQUIRED_QUANTITY) {
			Debug.Log("Se realiza la transicion hacia la ventana de Find Canvas");
			// si el modo AR se encuentra activo entonces se desactivara
			if (arCamera.activeSelf) {
				arCamera.SetActive(false);
				mainCamera.SetActive(true);
			}
			extractionCanvas.SetActive(false);
			extractionZone.SetActive(false);
			findCanvas.SetActive(true);
		}
	}
}
