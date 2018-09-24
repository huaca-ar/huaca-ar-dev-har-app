using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

	
	private static T instance;
	
	public static T Instance {
		get {
			 if(instance == null){
				 instance = FindObjectOfType<T>();
			 }
			 DontDestroyOnLoad(instance);
			 return instance;
		}
	}

	// no se necesita update ni start
	// static porque asi es un singleton...
}
