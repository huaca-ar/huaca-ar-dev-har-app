﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfileScreenManager : MonoBehaviour {

	// Use this for initialization
	
	public void LoadMapScene(){
		SceneManager.LoadScene(GameConstants.MAP_SCENE,LoadSceneMode.Single);
	}


}
