using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

	// Use this for initialization

	void Start(){
		
	}

	public void LoadMapScene(){
		SceneManager.LoadScene(GameConstants.MAP_SCENE,LoadSceneMode.Single);
	}	
	
	public void LoadProfileScene(){
		SceneManager.LoadScene(GameConstants.PROFILE_SCENE,LoadSceneMode.Single);
	}

	public void LoadExcavationScene(){
		SceneManager.LoadScene(GameConstants.EXCAVATION_SCENE,LoadSceneMode.Single);
	}
}
