using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProfileLoadAvatar : MonoBehaviour {
	private GameObject avatar;
	private GameObject avatarEmpty;
	static private float DISTANCE_TO_AVATAR = 0;

	// Use this for initialization
	void Start () {
		avatar = loadAvatar();
		RectTransform transform = GetComponent<RectTransform>();

		Vector3[] corners = new Vector3[4];
		transform.GetWorldCorners(corners);

		Vector3 centroid = (corners[0] + corners[1] + corners[2] + corners[3]) / 4;

		Renderer avatarRenderer = getGameObjectRenderer(avatar);

		if (avatarRenderer == null) {
			Debug.LogWarning("avatarRenderer is null.");
			return;
		}

		// In world coordinates.
		float height = Math.Abs(corners[0].y - corners[1].y);
		float scaleFactor = height / avatarRenderer.bounds.size.y;
		avatar.transform.localScale *= scaleFactor;

		avatarEmpty = new GameObject();
		avatarEmpty.transform.position = avatarRenderer.bounds.center;
		avatar.transform.SetParent(avatarEmpty.transform);
		avatarEmpty.transform.position = centroid;

		Debug.Log("pos: " + avatar.transform.position);
		Debug.Log("scale: " + avatar.transform.localScale);

		float avatarMaxDimension = Math.Max(avatarRenderer.bounds.size.x,
			Math.Max(avatarRenderer.bounds.size.y, avatarRenderer.bounds.size.z));

		avatarEmpty.transform.position +=
			new Vector3(0, 0, -avatarMaxDimension / 2 - DISTANCE_TO_AVATAR);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	Renderer getGameObjectRenderer(GameObject go) {
		Renderer renderer;
		renderer = avatar.GetComponent<Renderer>();
		if (renderer != null)
			return renderer;
		renderer = avatar.GetComponentInChildren<Renderer>();
		if (renderer != null)
			return renderer;
		// TODO
		// It might be the case in which there are multiple renderers.
		// Which render should we use?
		// Renderer []renderers = avatar.GetComponentsInChildren<Renderer>();
		return null;
	}

	GameObject loadAvatar() {
		string avatarPath = getAvatarPath();
		Debug.Log("Load avatar from " + avatarPath);
		avatar = AssetDatabase.LoadAssetAtPath(avatarPath, (typeof(GameObject))) as GameObject;
		avatar = Instantiate(avatar);
		return avatar;
	}

	string getAvatarPath() {
		// TODO
		// This path is hard-coded and should change according the chosen
		// avatar by the player.
		return "Assets/ArtDesign/3D/Avatares/MaleAvatar/No-Arte/B06_Ch_04_Avatar.prefab";
	}
}
