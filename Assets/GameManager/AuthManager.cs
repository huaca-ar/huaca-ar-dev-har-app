
using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour {


	const string SUFIX = "@arqueopucp.com";

	private bool usable;
	public static string nickname;

	[SerializeField] private InputField nickLogin, passLogin;
	// Use this for initialization
	[SerializeField] private InputField nickReg, passReg;

	[SerializeField] private GameObject statusLogin;

	
	
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

	

	public void LoginUser(){

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

					statusLogin.SetActive(true);
					statusLogin.GetComponent<Text>().text = "Usuario o Contraseña incorrectos";
					StartCoroutine(showStatusLogin(statusLogin));

				}

				FirebaseUser user = response.Result;
				Debug.LogFormat("Usuario logueado: {0}  {1}", user.Email, user.UserId);

				
				statusLogin.GetComponent<Text>().text = "Bienvenid" + (PlayerPrefs.GetInt("gender")==1 ? "o" : "a") + " "  +
				PlayerPrefs.GetString("nickname");
				statusLogin.SetActive(true);
				StartCoroutine(showStatusLogin(statusLogin));

				
				//Solicitar data a firebase para cargar estado del juego del usuario


				//esta actividad no deberia hacerse aca pero bue
				GameSceneManager manager =  FindObjectOfType<GameSceneManager>();
				manager.LoadMapScene();


			});

		}
		
	}

	IEnumerator showStatusLogin(GameObject gameObject){
		yield return new WaitForSeconds(2);
		gameObject.SetActive(false);
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
					return;
				}

				if(response.IsCanceled){
					SSTools.ShowMessage("Ocurrio un problema",SSTools.Position.bottom,SSTools.Time.twoSecond);
					return;
				}
				
				FirebaseUser newUser = response.Result;

				string[] cadenas = newUser.Email.Split('@');
				nickname = cadenas[0];

				Debug.LogFormat("USERID: {0} NICK: {1}", newUser.UserId, nickname);
				SSTools.ShowMessage("Bienvenido",SSTools.Position.bottom,SSTools.Time.oneSecond);

				SaveCurrentUserOnDisk();
				SaveUserDataOnDatabase();

				GameSceneManager sceneManager = FindObjectOfType<GameSceneManager>();
				sceneManager.LoadMapScene();
				

			});
		}
	}

	const string userIdTag = "userid";

	void SaveUserDataOnDatabase(){
		Player player = new Player();

		player.Nickname = nickname;
		player.Email = nickname+ SUFIX;
		


		DBManager manager = FindObjectOfType<DBManager>();
		//Deberia obtener la referencia al gameobject DBManager de la escena NewLogin

		manager.SaveNewUser(player);

		
		
		
		

    }
	void SaveCurrentUserOnDisk(){
		FirebaseUser currentUser = FirebaseAuth.DefaultInstance.CurrentUser;

		PlayerPrefs.SetString(userIdTag,currentUser.UserId);
		PlayerPrefs.SetString("nickname",nickname);
		
		


	}
}
