using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUIManager : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField] private GameObject menu;
	[SerializeField] private GameObject femaleAvatar;
	[SerializeField] private GameObject maleAvatar;
	private string uuid;
	private int gender;


	void Start(){
		setActiveAvatar(PlayerPrefs.GetInt("gender"));

	}

	void Update(){
		//Llamar a BD aca?
	}

	private  void setActiveAvatar(int gender){
		Debug.Log("llamada a setActiveAvatar");
		if(gender==1){
					maleAvatar.SetActive(true);
				}else{
					femaleAvatar.SetActive(true);
					}
	}

	public void toogleMenu(){
		menu.SetActive(!menu.activeSelf);
	}

	
}
