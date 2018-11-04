using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcavationAreaInteraction : MonoBehaviour {

	public GameObject GameController;
	public Transform staminaBar;
	public Slider staminaBarSlider;
	private int touchCount;
	private GameButtonsController buttonsController;
	// Use this for initialization

	private int exp = 500;
	void Start () {
		touchCount = 0;
		buttonsController = GameController.GetComponent<GameButtonsController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown() {
		touchCount++;
		Animator animator = gameObject.GetComponent<Animator>();
		animator.SetBool("dig", true);
		// se incrementa barra de stamina
		staminaBarSlider.value += 1.0f/ExcavationAreas.REQUIRED_QUANTITY;
		Debug.Log("Zona de excavacion tocada, nivel de stamina : " + staminaBarSlider.value);
		if (touchCount >= ExcavationAreas.REQUIRED_QUANTITY) {
			Debug.Log("Se realiza la transicion hacia la ventana de Find Canvas");
			buttonsController.goTofoundArtifact();
			// DatabaseReference personalInfo = FirebaseDatabase.DefaultInstance.RootReference.Child("Users").Child(PlayerPrefs.GetString("userid")).Child("PersonalInfo");

			exp = PlayerPrefs.GetInt("exp") + 500;
			PlayerPrefs.SetInt("exp",exp);
			// personalInfo.Child("exp").SetValueAsync(exp);
		}
	}
	
}
