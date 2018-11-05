using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Mapbox.Examples;

public class AvatarInteraction : MonoBehaviour {

	public GameObject map;
	public GameObject particleSystem;
	private SpawnOnMap spawnOnMap;
	public int touchCount;
	public Text coordinates;
	public double myLatitude;
	public double myLongitude;
	private Animator animator;
	private bool justFinishScan;
	void Awake() {
		spawnOnMap = map.GetComponent<SpawnOnMap>();
		animator = gameObject.GetComponent<Animator>();
	}

	void Start () {
		touchCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
			if (animator.GetBool("isScanning") == false && justFinishScan == true) {
				particleSystem.SetActive(false);
				spawnOnMap.enabled = true;
				justFinishScan = false;
			}
	}

	private void OnMouseDown() {
		particleSystem.SetActive(true);
		if (spawnOnMap.enabled == false) {
			

			animator.SetBool("isScanning",true);
			justFinishScan = true;

			Debug.Log("Se inicia escaneo de area .........");
			this.prepareGPSLocation();
			// this.myLatitude = 37.784179;
			// this.myLongitude = -122.401583; 
			touchCount++;
			coordinates.text = "Lat: " + this.myLatitude + ", Long: " + this.myLongitude + ", Touch: " + touchCount;
			List<string> locationsToSpawn = new List<string>();
			/* double[,] points = new double[5, 2];
			// si
			points[0,0] = -12.072320;
			points[0,1] = -77.080251;
			// si
			points[1,0] = -12.072298;
			points[1,1] = -77.080171;
			// si
			points[2,0] = -12.072278;
			points[2,1] = -77.080346;
			// si
			points[3,0] = -12.072184;
			points[3,1] = -77.080266;
			// no creo
			points[4,0] = -12.072129;
			points[4,1] = -77.080641; */
			// ahora se verifica si se encuentran en el radio de 100m
			double distance;
			for (int i=0;i<ExcavationAreas.EXCAVATION_ZONES.GetLength(0);i++) {
				distance = getDistance(this.myLatitude, this.myLongitude, ExcavationAreas.EXCAVATION_ZONES[i,0], ExcavationAreas.EXCAVATION_ZONES[i,1]);
				Debug.Log("Distancia " + (i+1) + ": " + distance);
				if (distance <= 100) {
					Debug.Log("El punto " + ExcavationAreas.EXCAVATION_ZONES[i,0] + ", " + ExcavationAreas.EXCAVATION_ZONES[i,1] + " se encuentra disponible para excavar");
					locationsToSpawn.Add(ExcavationAreas.EXCAVATION_ZONES[i,0].ToString() + ", " + ExcavationAreas.EXCAVATION_ZONES[i,1].ToString());
				}
			}
			Debug.Log("Cantidad de puntos seleccionados: "+ locationsToSpawn.Count);
			// una vez que se de un tap sobre el avatar entonces mostrara los profabs sobre el mapa
			spawnOnMap.setLocationPoints(locationsToSpawn.ToArray());
		}
		spawnOnMap.enabled = !spawnOnMap.enabled;
	}

	public void prepareGPSLocation() {
		if (!Input.location.isEnabledByUser) {
			Debug.Log("El GPS no se encuentra activado, operacion fallida");
			return;
		}
		if (Input.location.status == LocationServiceStatus.Stopped) {
			Debug.Log("Servicio de GPS se encuentra detenido, se volvera a activar");
			Input.location.Start();
			waitSomeTime(3);
			if (Input.location.status == LocationServiceStatus.Failed) {
				Debug.Log("Hubo un error al intentar conectarse al GPS");
				return;
			}
		}
		else if (Input.location.status == LocationServiceStatus.Initializing)
			waitSomeTime(3);
		else if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log("El servicio fallo al intentar activarse, cancelando operacion");
			return;
		}
		// cuando todo se encuentre validado entonces se asigna los valores de la posicion actual
		this.myLatitude = Input.location.lastData.latitude;
		this.myLongitude = Input.location.lastData.longitude;
	}
	private void waitSomeTime(int timeToWait) {
		int auxTime = timeToWait;
		while (Input.location.status == LocationServiceStatus.Initializing && auxTime > 0) {
			new WaitForSeconds(1);
			auxTime--;
		}
		Debug.Log("Espera finalizada");
		if (auxTime <=0)
			Debug.Log("TimeOut: tiempo de espera del servicio finalizado");
	}

	private double getDistance(double initialLatitude, double initialLongitude, double finalLatitude, double finalLongitude) {	// retorna en kilometros
		double theta = initialLongitude - finalLongitude;
		double distance = Math.Sin(deg2rad(initialLatitude))*Math.Sin(deg2rad(finalLatitude)) + Math.Cos(deg2rad(initialLatitude))*Math.Cos(deg2rad(finalLatitude))*Math.Cos(deg2rad(theta));
		distance = Math.Acos(distance);
		distance = rad2deg(distance);
		return distance*60*1.1515*1.609344*1000;
	}

	private double deg2rad(double deg) {
		return deg * Math.PI / 180.0;
	}

	private double rad2deg(double rad) {
		return rad / Math.PI * 180.0;
	}

}
