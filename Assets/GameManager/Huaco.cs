using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Huaco  {


	[SerializeField] private string type;
	[SerializeField] private int id;
	[SerializeField] private string name; // nombre del modelo 3D
    [SerializeField] private double latitud;
	[SerializeField] private double longitud;

	public Huaco(){

	}

    public string Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public double Latitud
    {
        get
        {
            return latitud;
        }

        set
        {
            latitud = value;
        }
    }

    public double Longitud
    {
        get
        {
            return longitud;
        }

        set
        {
            longitud = value;
        }
    }
}
