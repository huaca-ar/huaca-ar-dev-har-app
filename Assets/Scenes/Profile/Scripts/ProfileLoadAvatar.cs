using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProfileLoadAvatar : MonoBehaviour {
	static private float DISTANCE_TO_AVATAR = 0;
	static private float ROTATION_SPEED = 5.0f;
	private GameObject avatar;
	private GameObject avatarEmpty;

	// Rotation variables.
    private float _lastX;

	// Use this for initialization
	void Start () {
		Vector3[] corners = new Vector3[4];
		RectTransform transform;
		Renderer avatarRenderer;
		Vector3 centroid;
		float height, scaleFactor, avatarMaxDimension;

		avatar = loadAvatar();
		transform = GetComponent<RectTransform>();
		avatarRenderer = getGameObjectRenderer(avatar);

		if (!validateStart(avatar, transform, avatarRenderer))
			return;

		transform.GetWorldCorners(corners);
		centroid = (corners[0] + corners[1] + corners[2] + corners[3]) / 4;

		// Get height of this object in world coordinates.
		height = Math.Abs(corners[0].y - corners[1].y);
		scaleFactor = height / avatarRenderer.bounds.size.y;
		avatar.transform.localScale *= scaleFactor;

		// Create an empty and parent the avatar to this empty.
		avatarEmpty = new GameObject();
		avatarEmpty.transform.position = avatarRenderer.bounds.center;
		avatar.transform.SetParent(avatarEmpty.transform);
		avatarEmpty.transform.position = centroid;

		// We actually don't want the avatar to be exactly in the same
		// position of this object (intersecting it). So we move it enought
		// to avoid the avatar to intersect this object. Then we move it an
		// arbitrary distance DISTANCE_TO_AVATAR.

		avatarMaxDimension = Math.Max(avatarRenderer.bounds.size.x,
			Math.Max(avatarRenderer.bounds.size.y, avatarRenderer.bounds.size.z));
		avatarEmpty.transform.position +=
			new Vector3(0, 0, -avatarMaxDimension / 2 - DISTANCE_TO_AVATAR);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount <= 0)
			return;

		Touch touch = Input.GetTouch(0);
		if (touch.phase == TouchPhase.Moved) {
			float direction = -Math.Sign(touch.position.x - _lastX);
			avatarEmpty.transform.Rotate(Vector3.up, 5.0f * direction);
			_lastX = touch.position.x;
		}
	}

	bool validateStart(GameObject avatar, RectTransform transform,
		Renderer avatarRenderer) {
		if (avatar == null) {
			return false;
		}

		if (transform == null) {
			Debug.LogWarning("transform is null. Unexpected behaviors might present.");
			return false;
		}

		if (avatarRenderer == null) {
			Debug.LogWarning("avatarRenderer is null. Unexpected behaviors might present.");
			return false;
		}

		return true;
	}

	Renderer getGameObjectRenderer(GameObject go) {
		Renderer renderer;
		renderer = avatar.GetComponent<Renderer>();
		if (renderer != null) {
			return renderer;
		}
		renderer = avatar.GetComponentInChildren<Renderer>();
		if (renderer != null) {
			return renderer;
		}
		// TODO
		// It might be the case in which there are multiple renderers.
		// Which render should we use?
		// Renderer []renderers = avatar.GetComponentsInChildren<Renderer>();
		return null;
	}

	GameObject loadAvatar() {
		string avatarPath = getAvatarPath();
		Debug.Log(String.Format("Loading avatar from {0}", avatarPath));
		avatar = Resources.Load(avatarPath, (typeof(GameObject))) as GameObject;
		if (avatar == null) {
			Debug.LogWarning(
				String.Format("Cannot load the avatar from {0}", avatarPath));
		}
		avatar = Instantiate(avatar);
		return avatar;
	}

	string getAvatarPath() {
		// TODO
		// This path is hard-coded and should change according the chosen
		// avatar by the player.
		return "prueba/B06_Ch_04_Avatar";
	}
}
