using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUIManager : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField] private GameObject menu;
	[SerializeField] private GameObject femaleAvatar;
	[SerializeField] private GameObject maleAvatar;

	void Start(){
		

		if(PlayerPrefs.GetInt("gender") == 1){
			maleAvatar.SetActive(true);
		}else{
			femaleAvatar.SetActive(true);
		}
	}
	public void toogleMenu(){
		menu.SetActive(!menu.activeSelf);
	}

	
}
