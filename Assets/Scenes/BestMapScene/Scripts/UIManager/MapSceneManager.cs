using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSceneManager : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField]
	private GameObject menu;

	public void toogleMenu(){
		menu.SetActive(!menu.activeSelf);
	}

	public void openProfile(){
		//do something

		SceneManager.LoadScene(GameConstants.PROFILE_SCENE,LoadSceneMode.Single);
	}
}
