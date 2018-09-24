using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DroidFactory : Singleton<DroidFactory> {


	[SerializeField] private GameObject [] availableDroids;
	[SerializeField] private Player player;
	[SerializeField] private float waitTime = 	180.0f;
	[SerializeField] private int startingDroids = 5;
	[SerializeField] private float minRange = 5.0f;
	[SerializeField] private float maxRange = 50.0f;


	//Mantener la persistencia de la data
	//Si la escena se destruye la data se mantiene almacenada en estas variables

	private List<GameObject> liveDroids = new List<GameObject>();
	private Droid selectedDroid;

    

    private void Awake(){
		Assert.IsNotNull(availableDroids);
		Assert.IsNotNull(player);

	}


	// Use this for initialization
	void Start () {
		for(int i =0; i< startingDroids ; i++){
			InstantiateDroid();
		}
		StartCoroutine(GenerateDroids());
	}
	

	private IEnumerator GenerateDroids(){
		while(true){
			InstantiateDroid();
			yield return new WaitForSeconds(waitTime);
		}
		
	}

	
	public void DroidWasSelected(Droid droid){
		selectedDroid = droid;
	}
	
	private void InstantiateDroid(){
		//Define que droid voy a instanciar
		//Y ponerlo en un lugar en el mapa

		int index = Random.Range(0,availableDroids.Length);

		float x = player.transform.position.x + GenerateRange();
		float y = player.transform.position.y ;
		float z = player.transform.position.z + GenerateRange();
		
		
		//posible error
		liveDroids.Add(Instantiate(availableDroids[index], new Vector3(x,y,z), Quaternion.identity));

		// teniendo los puntos fijos dados por axel 
		// que deberia hacer ...
		// los huacos aparecen 1 por punto sin repeticion

		// un arreglo de huacos disponibles (availableArtifact)
		// un arreglo de posiciones de huacos
		// Una clase huaco que tenga :
		// GameObject (huaco)
		// Position (x,y,z)
		// Bool (encontrado o no)
		// Luego mediante un for instanciar cada objeto 
		// El punto inicial dentro del mapa hay que definirlo (cual es el centro)
		// Ya que no se va instanciar respecto al jugador

	}

	private float GenerateRange(){
		float randomNum =  Random.Range(minRange,maxRange);
		bool isPositive = Random.Range(0,10) < 5 ;
		return randomNum * (isPositive ? 1 : -1);

	}

	public List<GameObject> LiveDroids
    {
        get
        {
	       return liveDroids;
        }
    }

    public Droid SelectedDroid
    {
        get
        {
            return selectedDroid;
        }
	}

}
