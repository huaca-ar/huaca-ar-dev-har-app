using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DBManager : MonoBehaviour {


	const string SUFIX = "@arqueopucp.com";

	private bool usable;

	public InputField email, password;
	// Use this for initialization
	
	void Start(){
		Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
			var dependencyStatus = task.Result;
			if (dependencyStatus == Firebase.DependencyStatus.Available) {
				// Set a flag here indiciating that Firebase is ready to use by your
				// application.
				usable = true;
				
			} else {
				UnityEngine.Debug.LogError(System.String.Format(
				"Could not resolve all Firebase dependencies: {0}", dependencyStatus));
				// Firebase Unity SDK is not safe to use here.
				usable = false;
			}
		});	

		Debug.Log(usable);
	}

	

	public void LoginButtonPressed(){

		if(usable){
			string fakeEmail = email.text + SUFIX;
			
			Debug.Log(fakeEmail);

			FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(fakeEmail,password.text).
			ContinueWith((response)=>{
				
				if(response.IsCanceled){
					Debug.LogError("LOGIN CANCELADO");
				}
				if(response.IsFaulted){
					Debug.LogError("USUARIO O CONTRASEÑA INCORRECTOS");
					SSTools.ShowMessage("Usuario o Contraseña incorrectos", SSTools.Position.bottom,SSTools.Time.twoSecond);
				}

				FirebaseUser user = response.Result;
				Debug.LogFormat("Usuario logueado: {0}  {1}", user.Email, user.UserId);
				SSTools.ShowMessage("Bienvenido",SSTools.Position.bottom,SSTools.Time.twoSecond);

				GameSceneManager manager =  new GameSceneManager();
				manager.LoadMapScene();
			});

		}
		
	
		
		
	}

	
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool RegisterUser(){


		if(usable){
			
			string fakeEmail = email.text + SUFIX;
			Debug.Log(fakeEmail);

			FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(fakeEmail,password.text).ContinueWith((response)=>{

				if(response.IsFaulted){
					return false;
				}

				if(response.IsCanceled){
					return false;
				}
				
				FirebaseUser newUser = response.Result;



				string[] cadenas = newUser.Email.Split('@');

				Debug.LogFormat("USERID: {0} NICK: {1}", newUser.UserId, cadenas[0]);

				return true;
			});
		}
		
		
		return false;

	}
}
