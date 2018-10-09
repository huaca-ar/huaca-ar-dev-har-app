using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class LoginUIManager : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField]
	private GameObject existingUser;
	[SerializeField]
	private GameObject newUser;

	[SerializeField]
	private GameObject nickname;

	[SerializeField]
	private GameObject password;

	[SerializeField]
	private GameObject nickWarning;

	[SerializeField]
	private GameObject passWarning;

	[SerializeField]
	private DBManager dBManager;

	[SerializeField]
	private Image logo;

	[SerializeField]
	private GameObject startgame;
	[SerializeField]
	private GameObject loginTitle;

    private bool isValidData;

    public bool IsValidData
    {
        get
        {
            return isValidData;
        }

        set
        {
            isValidData = value;
        }
    }

    public void ExistingUserButtonPressed(){

		// ocultar los botones actuales

		existingUser.SetActive(false);
		newUser.SetActive(false);

		Vector3 position = logo.transform.position;
		logo.SetNativeSize();
		logo.transform.position = position + new Vector3(0,106,0);
		

		// activar botones de la vista iniciar sesion

		nickname.SetActive(true);
		password.SetActive(true);
		startgame.SetActive( true);
		loginTitle.SetActive(true);
		
	}


	public void validateNickname(){
		InputField myField = nickname.GetComponent<InputField>();


		if(myField.text.Length==0){
			SSTools.ShowMessage("Ingresar nickname",SSTools.Position.bottom,SSTools.Time.oneSecond);
			IsValidData=false;
			nickWarning.SetActive(true);
			return ;
		}

		if(myField.text.Length<4){
			IsValidData=false;
			SSTools.ShowMessage("Nick muy corto",SSTools.Position.bottom,SSTools.Time.oneSecond);
			nickWarning.SetActive(true);
			return;
		}
		IsValidData=true;
		nickWarning.SetActive(false);
		
	}
	
	public void validatePassword(){

		InputField myField = password.GetComponent<InputField>();

		if(myField.text.Length==0){
			IsValidData=false;
			SSTools.ShowMessage("Ingresar contraseña",SSTools.Position.bottom,SSTools.Time.oneSecond);
			passWarning.SetActive(true);
			return ;
		}
		if(myField.text.Length<6){
			IsValidData=false;
			SSTools.ShowMessage("Contraseña muy corta",SSTools.Position.bottom,SSTools.Time.oneSecond);
			passWarning.SetActive(true);
			return;
		}

		IsValidData=true;
		passWarning.SetActive(false);

	}

	public void StartGameButtonPressed(){

		// Debug.LogFormat("val nick: {0}  pass: {1}");

		Debug.LogFormat("Es data valida {0}",isValidData.ToString());

		if(IsValidData){			
			dBManager.LoginButtonPressed();
			passWarning.SetActive(false);
			nickWarning.SetActive(false);
			
		}
	
		
	}

	

}
