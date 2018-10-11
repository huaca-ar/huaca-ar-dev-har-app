using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Jugador  {

[SerializeField] private PersonalInfo personalInfo;
[SerializeField] private Awards awards ;
[SerializeField] private HuacoCollection recolectedItems;

    public Jugador()
    {
    }

    public PersonalInfo PersonalInfo
    {
        get
        {
            return personalInfo;
        }

        set
        {
            personalInfo = value;
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
}
