using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : PocketDroidsSceneManager
{
	
    private GameObject droid;
    private AsyncOperation loadScene;

    public override void droidTapped(GameObject droid)
    {
        //activar la captura del droid
		//cambiar de escena

		SceneManager.LoadScene(PocketDroidConstants.SCENE_CAPTURE,LoadSceneMode.Additive); 
        // SceneManager.LoadScene(PocketDroidConstants.SCENE_CAPTURE); 

    }

    public override void playerTapped(GameObject player)
    {
		
    }

    private void Start(){

    }

    private void Update(){
        
    }
}

//Game Manager
//move player between scene
//know which one is our player
