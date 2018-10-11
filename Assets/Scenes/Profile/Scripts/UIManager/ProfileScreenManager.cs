using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileScreenManager : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private Text exp;

	void Start(){
		exp.text = PlayerPrefs.GetInt("exp").ToString();
	}
	public void LoadMapScene(){
		SceneManager.LoadScene(GameConstants.MAP_SCENE,LoadSceneMode.Single);
	}


}
