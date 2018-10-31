using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSceneManager : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField]
	private GameObject menu;

	public Animator transitionAnim;
	public GameObject transitionCanvas;

	void Update() {
		if (transitionAnim.GetBool("finishIntro"))
			transitionCanvas.SetActive(false);
	}

	public void toogleMenu(){
		menu.SetActive(!menu.activeSelf);
	}

	public void openProfile(){
		//do something

		SceneManager.LoadScene(GameConstants.PROFILE_SCENE,LoadSceneMode.Single);
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
