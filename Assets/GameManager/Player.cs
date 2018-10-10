using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	private string uuid;
	private DateTime createdAt;
	private bool active;
	private GameInfo gameProgress;
	private string nickname;
	private string origin; // diferenciar google de local
	const int MAX_EXP = 100;

	public void addExp(int exp_gained){
		//hay que agregar la tabla de experiencia
		int temp = gameProgress.Exp +  exp_gained;


		if(temp > MAX_EXP){
			gameProgress.Exp = 0;
			gameProgress.Level+=1;
		}
	}



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
