using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUIManager : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField] private GameObject menu;
	[SerializeField] private GameObject femaleAvatar;
	[SerializeField] private GameObject maleAvatar;
	private string uuid;
	private int gender;


	public delegate void MyFunction();
	protected MyFunction callback;



	void Start(){
		// uuid = PlayerPrefs.GetString("userid");

		// Debug.LogFormat("Entre al metodo updateLocalInfo uuid {0}", uuid);

		// // isGenderAvailable(setActiveAvatar);
		// DatabaseReference personalInfo = FirebaseDatabase.DefaultInstance.RootReference.Child("Users").Child(uuid).Child("PersonalInfo");

		// personalInfo.Child("gender").GetValueAsync().ContinueWith((res)=>{


		// 	if(res.IsCompleted){
				
		// 		Debug.Log("ya culmino");

		// 		Debug.Log(res.Result.Value);
		// 		gender = (int) res.Result.Value;
		// 		PlayerPrefs.SetInt("gender",gender);
		// 		Debug.Log("usar callback");

		// 		setActiveAvatar(gender);
		// 	}
		// });

		// StartCoroutine(waitFire);


		setActiveAvatar(PlayerPrefs.GetInt("gender"));

	}

	// void Update(){
	// 	if(!femaleAvatar.activeSelf && !maleAvatar.activeSelf){
	// 		setActiveAvatar(PlayerPrefs.GetInt("gender"));
	// 	}
	// }

	// IEnumerator waitFire(){
	// 	yield return new WaitForSeconds(2);
	// 	setActiveAvatar(PlayerPrefs.GetInt("gender"));


	// }
	// void Awake(){
	// 	isGenderAvailable(setActiveAvatar);
		
	// }

	


	// private void isGenderAvailable(Action<int> callback){
	// 	DatabaseReference personalInfo = FirebaseDatabase.DefaultInstance.RootReference.Child("Users").Child(uuid).Child("PersonalInfo");

	// 	personalInfo.Child("gender").GetValueAsync().ContinueWith((res)=>{


	// 		if(res.IsCompleted){
				
	// 			Debug.Log(res.Result.Key);
	// 			Debug.Log(res.Result.Value.ToString());

	// 			Debug.Log("ya culmino");

	// 			Debug.Log(res.Result.Value);
	// 			gender = (int) res.Result.Value;
	// 			PlayerPrefs.SetInt("gender",gender);
	// 			Debug.Log("usar callback");
	// 			callback(gender);

	// 		}

				
	// 	});
	// }

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
