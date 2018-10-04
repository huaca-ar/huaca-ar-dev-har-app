using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaInteraction : MonoBehaviour {

	// Use this for initialization

	public GameObject area;
	

	private void OnMouseDown(){
		SceneManager.LoadScene(GameConstants.EXCAVATION_SCENE,LoadSceneMode.Single);
	}


}
