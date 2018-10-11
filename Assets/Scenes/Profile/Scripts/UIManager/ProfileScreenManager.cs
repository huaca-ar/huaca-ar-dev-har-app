using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileScreenManager : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private Text exp;
	[SerializeField] private GameObject maleAvatar;
	[SerializeField] private GameObject femaleAvatar;

	void Start(){
		exp.text = PlayerPrefs.GetInt("exp").ToString();


		if(PlayerPrefs.GetInt("gender")==1){
			maleAvatar.SetActive(true);
		}else{
			femaleAvatar.SetActive(true);
		}
	}

	public void LoadMapScene(){
		SceneManager.LoadScene(GameConstants.MAP_SCENE,LoadSceneMode.Single);
	}


}
