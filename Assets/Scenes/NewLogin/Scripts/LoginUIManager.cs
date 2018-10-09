using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class LoginUIManager : MonoBehaviour {

	// Use this for initialization
	
	[SerializeField] private GameObject existingUser;
	[SerializeField] private GameObject newUser;
	[SerializeField] private GameObject nickname;
	[SerializeField] private GameObject password;
	[SerializeField] private GameObject nickWarning;
	[SerializeField] private GameObject passWarning;
	[SerializeField] private DBManager dBManager;
	[SerializeField] private Image logo;
	[SerializeField] private GameObject startgame;
	[SerializeField] private GameObject loginTitle;
	[SerializeField] private GameObject chooseAvatarCanvas;
	[SerializeField] private GameObject firstCanvas;
	[SerializeField] private GameObject maleAvatar;
	[SerializeField] private GameObject femaleAvatar;

	// private GameObject loginCanvas;
	[SerializeField] private GameObject registerAccountCanvas;
	[SerializeField] private GameObject maleAvatarReg;
	[SerializeField] private GameObject femaleAvatarReg;




	private bool isMale = true;
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

    public bool IsMale
    {
        get
        {
            return isMale;
        }

        set
        {
            isMale = value;
        }
    }

    public void NewUserButtonPressed(){
		chooseAvatarCanvas.SetActive(true);
		firstCanvas.SetActive(false);
		 
	}

	public void RemoveFirstView(){
		existingUser.SetActive(false);
		newUser.SetActive(false);

		Vector3 position = logo.transform.position;
		logo.SetNativeSize();
		logo.transform.position = position + new Vector3(0,106,0);
	
	}
    public void ExistingUserButtonPressed(){

		// ocultar los botones actuales

		RemoveFirstView();

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

	public void MaleButtonPressed(){
		maleAvatar.SetActive(true);
		femaleAvatar.SetActive(false);
		IsMale = true;
		Debug.LogFormat("Escoge hombre : {0}", IsMale.ToString() );
	}
	public void FemaleButtonPressed(){
		maleAvatar.SetActive(false);
		femaleAvatar.SetActive(true);
		IsMale = false;

		Debug.LogFormat("Escoge mujer : {0}", (!IsMale).ToString() );
	}

	public void NextButtonPressed(){
		chooseAvatarCanvas.SetActive(false);
		registerAccountCanvas.SetActive(true);
		if(IsMale){
			maleAvatarReg.SetActive(true);
		}else{
			femaleAvatarReg.SetActive(true);
		}
		
	}


}
