using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player  {

	// Use this for initialization
	// private string uuid;
	// private GameInfo gameProgress;
	
    [SerializeField] private string createdAt;
	[SerializeField] private bool active;
    [SerializeField] private string email;
	[SerializeField] private string nickname;
	[SerializeField] private string origin; // diferenciar google de local
    [SerializeField] private int exp;
    [SerializeField] private int level;
    [SerializeField]  private int gender;
    [SerializeField] private bool isTutorialDone;
    
    [SerializeField] private Awards awards;





    public string CreatedAt
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

   

    public int Exp
    {
        get
        {
            return exp;
        }

        set
        {
            exp = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int Gender
    {
        get
        {
            return gender;
        }

        set
        {
            gender = value;
        }
    }

    public bool IsTutorialDone
    {
        get
        {
            return isTutorialDone;
        }

        set
        {
            isTutorialDone = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public Awards Awards
    {
        get
        {
            return awards;
        }

        set
        {
            awards = value;
        }
    }

    public Player(){
        
        CreatedAt = System.DateTime.Now.ToString();
		Active = true;
		Origin = "App";
		Exp = 0;
		Level = 1;
		IsTutorialDone = false;
		
    }



    
}
