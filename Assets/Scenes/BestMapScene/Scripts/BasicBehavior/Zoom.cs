using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Examples;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using UnityEngine;

public class Zoom : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame


	public AbstractMap _mapManager;
	[SerializeField]
	float _zoomSpeed = 0.15f;
	float spawnScale = 18f;

	[SerializeField]
	private GameObject femaleAvatar;
	[SerializeField]
	private GameObject maleAvatar;

	private GameObject selectedAvatar;
	private Vector2d position;
	public  Transform target;

	void Start () {

		if(femaleAvatar.activeSelf){
			selectedAvatar = femaleAvatar;
		}else{
			selectedAvatar = maleAvatar;
		}



	}



	void Update(){
		if(Input.touchCount == 2){
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			//delta position guarda la diferencia entre dos posiciones 
			//es un vector2
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;

		    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			float deltaMagnitudDiff = (touchDeltaMag -prevTouchDeltaMag)*0.01f;

		
			Debug.Log("desactivar movimiento");
			selectedAvatar.GetComponent<AvatarMovement>().enabled = false;
			this.ZoomMapUsingTouchOrMouse(deltaMagnitudDiff);
			selectedAvatar.GetComponent<AvatarMovement>().enabled = true;
			Debug.Log("activar movimiento");
			// en base a este script se puede subir y bajar el zoom property 
			// haciendo un mod % 4 
		}
	}

	void ZoomMapUsingTouchOrMouse(float zoomFactor)
		{
			var zoom = Mathf.Max(0.0f, Mathf.Min(_mapManager.Zoom + zoomFactor * _zoomSpeed, 21.0f));


			if (Math.Abs(zoom - _mapManager.AbsoluteZoom) > 0.1f)
			{
				if(zoom >= 18 && zoom <= 20){

					// GetComponent<AvatarInteraction>().prepareGPSLocation();
					// Vector2d position = new Vector2d(GetComponent<AvatarInteraction>().myLatitude,GetComponent<AvatarInteraction>().myLongitude);
					// Vector2d position = new Vector2d(1);
					// _mapManager.UpdateMap( position , zoom);
					gpsLocation();
					// _mapManager.SetCenterLatitudeLongitude(position);
					_mapManager.UpdateMap( _mapManager.CenterLatitudeLongitude , zoom);
					// choosedAvatar.transform.localPosition = _mapManager.GeoToWorldPosition(position);
					target.transform.localPosition = _mapManager.GeoToWorldPosition(position,true);

					
					// _mapManager.GeoToWorldPosition()
					selectedAvatar.transform.localPosition = _mapManager.GeoToWorldPosition(position,true);
					selectedAvatar.transform.localScale= new Vector3(spawnScale,spawnScale,spawnScale);
					// spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
				}
			}
			


		}

		public void gpsLocation() {
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


		position = new Vector2d (Input.location.lastData.latitude,Input.location.lastData.longitude);
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

	
}
