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
	public GameObject circleAnimation;

	public Animator transitionAnim;
	public GameObject transitionCanvas;





	void Start(){
		

		setActiveAvatar(PlayerPrefs.GetInt(GameConstants.GENDER_TAG));

		


	}

	

	void Update() {
		if (transitionAnim.GetBool("finishIntro"))
			transitionCanvas.SetActive(false);

		if(maleAvatar.activeSelf){
			circleAnimation.transform.position = maleAvatar.transform.position + new Vector3(0,2,0);
		}else{
			circleAnimation.transform.position = femaleAvatar.transform.position + new Vector3(0,2,0);
		}	
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

	public void transitionEffect(string SceneName) {
		StartCoroutine(this.LoadScene(SceneName));
	}

	IEnumerator LoadScene(string SceneName) {
		transitionAnim.SetTrigger("end");
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(SceneName);
	}


	
}
