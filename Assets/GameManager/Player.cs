using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	// private string uuid;
	private DateTime createdAt;
	private bool active;
	private GameInfo gameProgress;
	private string nickname;
	private string origin; // diferenciar google de local
	const int MAX_EXP = 100;



    public Player (){

    }
    public DateTime CreatedAt
    {
        get
        {
            return createdAt;
        }

        set
        {
            createdAt = value;
        }
    }

    public bool Active
    {
        get
        {
            return active;
        }

        set
        {
            active = value;
        }
    }

    public GameInfo GameProgress
    {
        get
        {
            return gameProgress;
        }

        set
        {
            gameProgress = value;
        }
    }

    public string Nickname
    {
        get
        {
            return nickname;
        }

        set
        {
            nickname = value;
        }
    }

    public string Origin
    {
        get
        {
            return origin;
        }

        set
        {
            origin = value;
        }
    }

    public void addExp(int exp_gained){
		//hay que agregar la tabla de experiencia
		int temp = GameProgress.Exp +  exp_gained;


		if(temp > MAX_EXP){
			GameProgress.Exp = 0;
			GameProgress.Level+=1;
		}
	}



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
