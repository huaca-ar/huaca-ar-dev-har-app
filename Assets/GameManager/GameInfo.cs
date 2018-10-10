using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo {

	private int exp;
	private int gender;
	private bool isTutorialDone;
	private int level;
	private HuacoCollection recolectedItems;

	public GameInfo(){
		
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

    public HuacoCollection RecolectedItems
    {
        get
        {
            return recolectedItems;
        }

        set
        {
            recolectedItems = value;
        }
    }




    // 40 vasos cada uno tiene un id 
    // un model 3D
    // una posicion latitud longitud
    // tipo
}
