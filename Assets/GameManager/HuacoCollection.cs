using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class HuacoCollection  {

	// Use this for initialization
	[SerializeField]private List<Huaco> bottles;
	[SerializeField]private List<Huaco> figurines;
	[SerializeField]private List<Huaco> pitchers;
	[SerializeField]private List<Huaco> pot;
	[SerializeField]private int current_bottles;
	[SerializeField]private int current_pitchers;
	[SerializeField]private int current_pots;
	[SerializeField]private int current_figurines;

    public HuacoCollection(){
        bottles =    new List<Huaco>();
        figurines = new List<Huaco>();
        pitchers = new List<Huaco>();
        pot = new List<Huaco>();
    }

    

    public int Current_bottles
    {
        get
        {
            return current_bottles;
        }

        set
        {
            current_bottles = value;
        }
    }

    public int Current_pitchers
    {
        get
        {
            return current_pitchers;
        }

        set
        {
            current_pitchers = value;
        }
    }

    public int Current_pots
    {
        get
        {
            return current_pots;
        }

        set
        {
            current_pots = value;
        }
    }

    public int Current_figurines
    {
        get
        {
            return current_figurines;
        }

        set
        {
            current_figurines = value;
        }
    }

    public List<Huaco> Bottles
    {
        get
        {
            return bottles;
        }

        set
        {
            bottles = value;
        }
    }

    public List<Huaco> Figurines
    {
        get
        {
            return figurines;
        }

        set
        {
            figurines = value;
        }
    }

    public List<Huaco> Pitchers
    {
        get
        {
            return pitchers;
        }

        set
        {
            pitchers = value;
        }
    }

    public List<Huaco> Pot
    {
        get
        {
            return pot;
        }

        set
        {
            pot = value;
        }
    }
}
