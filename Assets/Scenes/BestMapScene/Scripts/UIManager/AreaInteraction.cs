using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaInteraction : MonoBehaviour {

	// Use this for initialization

	public GameObject area;
	public GameObject mapSceneManagerGO;
	private MapSceneManager mapSceneManager;

	void Awake() {
		//mapSceneManager = mapSceneManagerGO.GetComponent<MapSceneManager>();
	}

	private void OnMouseDown(){
		// aquí va el trigger para el inicio de la transicion
		//SceneManager.LoadScene(GameConstants.EXCAVATION_SCENE,LoadSceneMode.Single);
		mapSceneManagerGO = GameObject.FindWithTag("SceneManager");
		mapSceneManager = mapSceneManagerGO.GetComponent<MapSceneManager>();
		mapSceneManager.transitionEffect(GameConstants.EXCAVATION_SCENE);
	}


}
