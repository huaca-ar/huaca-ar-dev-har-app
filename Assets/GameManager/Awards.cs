using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Awards  {

	[SerializeField] private int digQuantity;
	[SerializeField] private int searchQuantity;
	[SerializeField] private int gatherQuantity;

	public Awards(){

	}

    public int DigQuantity
    {
        get
        {
            return digQuantity;
        }

        set
        {
            digQuantity = value;
        }
    }

    public int SearchQuantity
    {
        get
        {
            return searchQuantity;
        }

        set
        {
            searchQuantity = value;
        }
    }

    public int GatherQuantity
    {
        get
        {
            return gatherQuantity;
        }

        set
        {
            gatherQuantity = value;
        }
    }
}
