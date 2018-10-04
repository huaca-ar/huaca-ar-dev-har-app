﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AvatarInteraction : MonoBehaviour {

	public int touchCount;
	public Text coordinates;
	public double myLatitude;
	public double myLongitude;
	// Use this for initialization
	void Start () {
		touchCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown() {
		this.prepareGPSLocation();
		coordinates.text = "Lat: " + this.myLatitude + ", Long: " + this.myLongitude + ", Touch: " + touchCount;
		touchCount++;
		Debug.Log("Se inicia escaneo de area .........");
		double[,] points = new double[5, 2];
		// mi posicion actual
		//double miLat = -12.072164;
		//double miLong = -77.080380;
		// colocar aqui los puntos
		// si
		points[0,0] = -12.072155;
		points[0,1] = -77.080083;
		// si
		points[1,0] = -12.072126;
		points[1,1] = -77.080616;
		// no creo
		points[2,0] = -12.071630;
		points[2,1] = -77.080156;
		// no creo
		points[3,0] = -12.071454;
		points[3,1] = -77.079743;
		// no creo
		points[4,0] = -12.072555;
		points[4,1] = -77.079443;
		// ahora se verifica si se encuentran en el radio de 100m
		double distance;
		for (int i=0;i<5;i++) {
			distance = getDistance(this.myLatitude, this.myLongitude, points[i,0], points[i,1]);
			if (distance <= 100)
				Debug.Log("El punto " + points[i,0] + ", " + points[i,1] + " se encuentra disponible para excavar");
		}
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
