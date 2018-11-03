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

	[SerializeField] private Text nickname;

	void Start(){
		exp.text = PlayerPrefs.GetInt(GameConstants.EXP_TAG).ToString();
		nickname.text = PlayerPrefs.GetString(GameConstants.NAME_TAG);

		if(PlayerPrefs.GetInt(GameConstants.GENDER_TAG)==1){
			maleAvatar.SetActive(true);
		}else{
			femaleAvatar.SetActive(true);
		}
	}

	


}
