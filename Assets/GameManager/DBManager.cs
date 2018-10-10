using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class DBManager : MonoBehaviour {

	// Use this for initialization

	DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
	DatabaseReference rootReference =  FirebaseDatabase.DefaultInstance.RootReference;

	protected virtual void Start () {
		
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


	public void SaveNewUser(Player player){

		DatabaseReference currentUserReference = rootReference.Child(PlayerPrefs.GetString("userid"));
		string json = JsonUtility.ToJson(player);

		Debug.Log("Intento guardar datos en firebase");
		currentUserReference.SetRawJsonValueAsync(json);
		

	}


}
