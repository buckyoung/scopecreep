using UnityEngine;
using System.Collections;

public class GetInfo : MonoBehaviour {
	public Transform target;
	Camera camera;

	void Start() {
		camera = GetComponent<Camera>();
	}

	void Update() {
		Vector3 screenPos = camera.WorldToScreenPoint(target.position);
		Debug.Log("target is " + screenPos.x + " pixels from the left");
	}
}