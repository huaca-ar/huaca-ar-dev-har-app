using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBServiceManager : MonoBehaviour {

	// Use this for initialization


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoginUser(){
		// Llamar al servicio para hacer el login

		// LLenar datos del usuario en disco del dispositivo
		// PlayerPrefabs permite almacenar data como bool int y string

		// Obtener informacion del servicio
		int exp = 0;
		int gender = 1; //1 hombre 0 mujer
		string name = "LogUser";
		int level = 1;

		SetupPlayerProfile(name,gender,level,exp);

	}

	public void CreateUser(){
		// La informacion se obtiene de los text fields usados en la interfaz grafica (RegisterCanvas y ChooseAvatarCanvas en escena Login)
		// Mientras se navegó en en los canvas se fue guardando en los PlayerPrefabs la informacion de genero y nombre (password) 
		// Password encriptar?

		// Se debe guardar la informacion del usuario en el servicio

		Jugador jugador = new Jugador();
		Awards awards = new Awards();
		HuacoCollection huacoCollection = new HuacoCollection();

		//El constructor llena la informacion basica del nuevo jugador con los datos que ha ingresado.
		//La password no se habia guardado en firebase porque lo manejaba con el authentication toncs ... habra que agregarlo
		PersonalInfo personalInfo = new PersonalInfo(); 



		//Colocar informacion del jugador en la clase
		jugador.Awards = awards;
		jugador.RecolectedItems = huacoCollection;
		jugador.PersonalInfo = personalInfo;

		//Llamar al servicio para guardar al jugador en la nube.

			
	}

	void SetupPlayerProfile(string name, int gender, int level, int exp){
		PlayerPrefs.SetInt(GameConstants.EXP_TAG,exp);
		PlayerPrefs.SetInt(GameConstants.GENDER_TAG,gender);
		PlayerPrefs.SetString(GameConstants.NAME_TAG, name);
		PlayerPrefs.SetInt(GameConstants.LEVEL_TAG, level);
	}




}
