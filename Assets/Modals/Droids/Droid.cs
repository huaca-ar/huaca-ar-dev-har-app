using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour {


    [SerializeField] private float spawnRate = 0.10f;
    [SerializeField] private float catchRate = 0.10f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defense = 0;
    [SerializeField] private int hp = 0; // solo hp para los huacos

    

    private void OnMouseDown()
    {
        PocketDroidsSceneManager[] managers = FindObjectsOfType<PocketDroidsSceneManager>();   
        //Lo que entiendo
        //Por cada objeto dentro de la escena que sea de tipo pocketdroidscenemanager
        //Se valida si esta activo (se busca al que fue tocado "tapped")
        //Lo encuentra y se activa el metodo droidTapped

        foreach (PocketDroidsSceneManager pm in managers){
            if(pm.gameObject.activeSelf){
                pm.droidTapped(this.gameObject);
            }
        }
    }


    // Use this for initialization
    private void Start () {
        //Necesario para que no se destruya el droid tocado cuando se cambie de escena
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public float SpawnRate
    {
        get
        {
            return spawnRate;
        }

        set
        {
            spawnRate = value;
        }
    }

    public float CatchRate
    {
        get
        {
            return catchRate;
        }

        set
        {
            catchRate = value;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }
}
