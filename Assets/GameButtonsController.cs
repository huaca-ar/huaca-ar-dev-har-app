using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsController : MonoBehaviour {

	public GameObject extractionCanvas;
	public GameObject extractionZone;
	public GameObject findCanvas;
	public GameObject arCamera;
	public GameObject mainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ARButton() {
		Debug.Log("Se acaba de pulsar el boton de AR");
		this.normalExtToARExt();
	}



	public void normalExtToARExt() {
		mainCamera.SetActive(false);
		extractionCanvas.SetActive(false);
		arCamera.SetActive(true);
	}

	public void ARExtToNormalExt() {
		arCamera.SetActive(false);
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
