using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsController : MonoBehaviour {

	public GameObject StaminaBar;
	public GameObject arButton;
	public GameObject ARCanvas;
	public GameObject extractionCanvas;
	public GameObject extractionZone;
	public GameObject findCanvas;
	public GameObject arCamera;
	public GameObject mainCamera;
	public GameObject transitionCanvas;
	public Animator transitionAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		if (transitionAnim.GetBool("finishIntro"))
			transitionCanvas.SetActive(false);
	}

	public void ARButton() {
		Debug.Log("Se acaba de pulsar el boton de AR");
		if (!this.isARActivated())
			this.normalExtToARExt();
		else
			this.ARExtToNormalExt();
	}



	public void normalExtToARExt() {
		mainCamera.SetActive(false);
		StaminaBar.transform.SetParent(ARCanvas.transform, false);
		arButton.transform.SetParent(ARCanvas.transform, false);
		extractionCanvas.SetActive(false);
		arCamera.SetActive(true);
		ARCanvas.SetActive(true);
	}

	public void ARExtToNormalExt() {
		arCamera.SetActive(false);
		StaminaBar.transform.SetParent(extractionCanvas.transform, false);
		arButton.transform.SetParent(extractionCanvas.transform, false);
		extractionCanvas.SetActive(true);
		mainCamera.SetActive(true);
	}

	public void goTofoundArtifact() {
		if (this.isARActivated()) {			// Modo de extracion AR activado
			arCamera.SetActive(false);
			mainCamera.SetActive(true);
		}
		else								// Modo de extraccion normal activado
			extractionCanvas.SetActive(false);
		// se desactiva modelo 3D
		extractionZone.SetActive(false);
		// se activa interfaz de artefacto encontrado
		findCanvas.SetActive(true);
	}

	public bool isARActivated() {
		return (arCamera.activeSelf == true) && (mainCamera.activeSelf == false);
	}

}
