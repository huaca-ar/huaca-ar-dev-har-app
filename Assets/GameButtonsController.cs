using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsController : MonoBehaviour {

	public GameObject extractionCanvas;
	public GameObject ARCamera;
	public GameObject extractionZoneAR;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ARButton() {
		Debug.Log("Se acaba de pulsar el boton de AR");
		ARCamera.SetActive(!ARCamera.activeSelf);
		extractionZoneAR.SetActive(!extractionZoneAR.activeSelf);
		extractionCanvas.SetActive(!extractionCanvas.activeSelf);
		//
		setExcavationZoneAR();
	}

	public void setExcavationZoneAR() {
		Debug.Log("Se inicia seteo de posicion de zona de excavacion AR");
		//extractionZoneAR.transform.position = new Vector3(extractionZoneAR.transform.position.x, extractionZoneAR.transform.position.y, (Random.insideUnitSphere.z * 20.0f));
		//Vector3 playerPosition = new Vector3(extractionZoneAR.transform.position.x, extractionZoneAR.transform.position.y, ARCamera.transform.position.z);
		//extractionZoneAR.transform.LookAt(playerPosition);
	}

}
