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
	[SerializeField] private Image logo;
	
	// [SerializeField] private AuthManager authManager;
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
	
	[SerializeField] private GameObject nickReg;
	[SerializeField] private GameObject passReg;

	[SerializeField] private GameObject nickWarningReg;
	
	[SerializeField] private GameObject passWarningReg;




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


	void Start(){

		//probar con el login
		// InputField nickLogin = nickname.GetComponent<InputField>();
		// nickLogin.onEndEdit.AddListener(delegate{
		// 	ValidateNickname(nickLogin.text);
		// 	});

		// InputField passLogin = password.GetComponent<InputField>();
		// passLogin.onEndEdit.AddListener(delegate{
		// 	ValidatePassword(passLogin.text);
		// });

		AddListenerPass(password, passWarning);
		AddListenerNick(nickname, nickWarning) ;
		AddListenerNick(passReg, nickWarningReg);
		AddListenerPass(passReg, passWarningReg);

		//Eliminar todas las claves cuando inicia el juego
		// PlayerPrefs.DeleteAll();
		
	}

	void AddListenerPass(GameObject gameObject, GameObject warn){
		InputField myfield = gameObject.GetComponent<InputField>();
		myfield.onEndEdit.AddListener(delegate{
			ValidatePassword(myfield.text, warn);
		});

	}

	void AddListenerNick(GameObject gameObject, GameObject warn){
		InputField myfield = gameObject.GetComponent<InputField>();
		myfield.onEndEdit.AddListener(delegate{
			ValidateNickname(myfield.text, warn);
		});

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
		logo.rectTransform.position = position + new Vector3(0,150,0);
		// logo.rectTransform.position = position + new Vector3(0,180,0);
		

		
	
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


	public void ValidateNickname(string value, GameObject nickWarn){

		if(value.Length==0){
			nickWarn.GetComponent<Text>().text = "Debe ingresar un nickname";
			IsValidData=false;
			nickWarn.SetActive(true);
			return ;
		}

		if(value.Length<4){
			IsValidData=false;
			nickWarn.GetComponent<Text>().text = "Nickname muy corto";
			nickWarn.SetActive(true);
			return;
		}
		IsValidData=true;
		nickWarn.SetActive(false);
		
	}
	
	public void ValidatePassword(string myField, GameObject passWarn){

		if(myField.Length==0){
			IsValidData=false;
			passWarn.SetActive(true);
			passWarn.GetComponent<Text>().text = "Debe ingresar una contraseña";
			return ;
		}
		if(myField.Length<6){
			IsValidData=false;
			passWarn.SetActive(true);
			passWarn.GetComponent<Text>().text = "Contraseña muy corta";
			return;
		}

		IsValidData=true;
		passWarn.SetActive(false);

	}

	public void StartGameButtonPressed(){

		// Debug.LogFormat("val nick: {0}  pass: {1}");

		Debug.LogFormat("Es data valida {0}",isValidData.ToString());

		if(IsValidData){			
			// authManager.LoginUser();
			GetComponent<GameSceneManager>().LoadMapScene();
			passWarning.SetActive(false);
			nickWarning.SetActive(false);
			
		}
		
	}


	public void NextButtonPressed(){
		chooseAvatarCanvas.SetActive(false);
		registerAccountCanvas.SetActive(true);
		if(IsMale){
			maleAvatarReg.SetActive(true);
		}else{
			femaleAvatarReg.SetActive(true);
		}
		// 1 hombre
		// 0 mujer
		PlayerPrefs.SetInt("gender",IsMale ? 1 : 0);
	
	}

	public void RegisterButtonPressed(){
		Debug.LogFormat("En el registro es data valida {0}",isValidData.ToString());

		if(IsValidData){			
			// authManager.RegisterUser();
			passWarningReg.SetActive(false);
			nickWarningReg.SetActive(false);
			GetComponent<GameSceneManager>().LoadMapScene();
			
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
	


}
