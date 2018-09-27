using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField]
	private GameObject menu;

	public void toogleMenu(){
		menu.SetActive(!menu.activeSelf);
	}

	public void openProfile(){
		//do something
	}
}
