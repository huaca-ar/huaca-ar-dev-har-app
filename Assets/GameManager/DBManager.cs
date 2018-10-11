using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour {

	// Use this for initialization

	DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
	DatabaseReference rootReference;
	[SerializeField] 
	private GameObject status;	

	public static PersonalInfo info;

	protected virtual void Start () {

		rootReference =  FirebaseDatabase.DefaultInstance.RootReference;
		
		FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
        dependencyStatus = task.Result;
        if (dependencyStatus == DependencyStatus.Available) {
          InitializeFirebase();
        } else {
          Debug.LogError(
            "Could not resolve all Firebase dependencies: " + dependencyStatus);
        }
      });


		


	}
	 protected virtual void InitializeFirebase() {
      FirebaseApp app = FirebaseApp.DefaultInstance;
      // NOTE: You'll need to replace this url with your Firebase App's database
      // path in order for the database connection to work correctly in editor.
      app.SetEditorDatabaseUrl("https://arqueopucp.firebaseio.com/");
      if (app.Options.DatabaseUrl != null)
        app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
    
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SaveNewUser(PersonalInfo player	){

		SaveCurrentUserOnDisk(player.Nickname);


		DatabaseReference currentUserReference = rootReference.Child("Users").Child(PlayerPrefs.GetString("userid"));
		string json = JsonUtility.ToJson(player);
		Debug.LogFormat("User ID en playerprefs: {0}", PlayerPrefs.GetString("userid"));

		Debug.Log("Intento guardar datos en firebase");

		currentUserReference.Child("PersonalInfo").SetRawJsonValueAsync(json,1);

		HuacoCollection coleccion = new HuacoCollection();
		json = JsonUtility.ToJson(coleccion);


		currentUserReference.Child("RecolectedItems").SetRawJsonValueAsync(json);

		Awards awards = new Awards();
		json= JsonUtility.ToJson(awards);

		currentUserReference.Child("Awards").SetRawJsonValueAsync(json);


	}

	public void TestSave(){

		//recolectedItems
		// HuacoCollection coleccion = new HuacoCollection();

		// Huaco botella = new Huaco();

		// botella.Name= "botella N123";
		// botella.Latitud = 123.23111;
		// botella.Longitud = 12.7231;
		// botella.Id = 12;
		// botella.Type= "botella";
		
		// Huaco figurine = new Huaco();
		

		// figurine.Name= "botella N123";
		// figurine.Latitud = 123.23111;
		// figurine.Longitud = 12.7231;
		// figurine.Id = 12;
		
		// figurine.Type = "figurine";
		// Huaco pitcher = new Huaco();

		// pitcher.Name= "botella N123";
		// pitcher.Latitud = 123.23111;
		// pitcher.Longitud = 12.7231;
		// pitcher.Id = 12;
		// pitcher.Type= "pitchers";
		
		// Huaco pot = new Huaco();

		// pot.Name= "botella N123";
		// pot.Latitud = 123.23111;
		// pot.Longitud = 12.7231;
		// pot.Id = 12;
		// pot.Type = "figurine";

		// coleccion.Bottles.Add(botella);
		// coleccion.Bottles.Add(botella);

		// coleccion.Figurines.Add(figurine);
		// coleccion.Figurines.Add(figurine);
		// coleccion.Figurines.Add(figurine);
		// coleccion.Pitchers.Add(pitcher);
		// coleccion.Pitchers.Add(pitcher);
		// coleccion.Pitchers.Add(pitcher);
		// coleccion.Pitchers.Add(pitcher);
		// coleccion.Pot.Add(pot);
		

		// DatabaseReference testUserReference = rootReference.Child("Users").Child("iy0z2HeNGhVselzhKggHfWyPUt42");

		// string json =  JsonUtility.ToJson(coleccion);

		// Debug.LogFormat("Json: {0}",json);
		// testUserReference.SetRawJsonValueAsync(json);

		DatabaseReference personalInfo = rootReference.Child("Users").Child("b7kXAhzUcrdgRdeLEPq9kUqSecJ2").Child("PersonalInfo");

		
		personalInfo.GetValueAsync().ContinueWith((res)=>{

			res.Result.HasChild("PersonalInfo");
			if(res.IsCompleted){
				string json = JsonUtility.ToJson( (PersonalInfo) res.Result.Value ) ;
				Debug.Log(json);

				PersonalInfo info = (PersonalInfo) res.Result.Value;
				// SaveCurrentUserOnDisk("pepe");
				PlayerPrefs.SetString("userid","b7kXAhzUcrdgRdeLEPq9kUqSecJ2");
				PlayerPrefs.SetString("nickname","pepe");
				PlayerPrefs.SetInt("gender", info.Gender);

				Debug.Log(PlayerPrefs.GetInt("gender"));

				Debug.Log("Antes de cambiar de mapa");
				GameSceneManager sceneManager = new GameSceneManager();
				sceneManager.LoadMapScene();
				PlayerPrefs.SetInt("exp",info.Exp);
			}


		});

	}



		void SaveCurrentUserOnDisk(string nickname){
		FirebaseUser currentUser = FirebaseAuth.DefaultInstance.CurrentUser;

		PlayerPrefs.SetString("userid",currentUser.UserId);
		PlayerPrefs.SetString("nickname",nickname);
		
		
		


	}

	IEnumerator showStatusLogin(GameObject gameObject){
		yield return new WaitForSeconds(2);
		gameObject.SetActive(false);
	}
	


}
