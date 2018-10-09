using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DBManager : MonoBehaviour {


	const string SUFIX = "@arqueopucp.com";

	private bool usable;

	[SerializeField] private InputField nickLogin, passLogin;
	// Use this for initialization
	[SerializeField] private InputField nickReg, passReg;
	
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
			string fakeEmail = nickLogin.text + SUFIX;
			
			Debug.Log(fakeEmail);

			FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(fakeEmail,passLogin.text).
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

				//esta actividad no deberia hacerse aca pero bue
				GameSceneManager manager =  new GameSceneManager();
				manager.LoadMapScene();
			});

		}
		
	
		
		
	}

	
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RegisterUser(){


		if(usable){
			
			string fakeEmail = nickReg.text + SUFIX;
			Debug.Log(fakeEmail);

			FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(fakeEmail,passReg.text).ContinueWith((response)=>{

				if(response.IsFaulted){
					SSTools.ShowMessage("El nick ya existe",SSTools.Position.top,SSTools.Time.twoSecond);
				}

				if(response.IsCanceled){
					SSTools.ShowMessage("Ocurrio un problema",SSTools.Position.bottom,SSTools.Time.twoSecond);
				}
				
				FirebaseUser newUser = response.Result;

				string[] cadenas = newUser.Email.Split('@');

				Debug.LogFormat("USERID: {0} NICK: {1}", newUser.UserId, cadenas[0]);
				SSTools.ShowMessage("Bienvenido",SSTools.Position.bottom,SSTools.Time.oneSecond);

				//esta actividad no deberia hacerse aca pero bue
				GameSceneManager manager =  new GameSceneManager();
				manager.LoadMapScene();

			});
		}
		
		
		

	}
}
