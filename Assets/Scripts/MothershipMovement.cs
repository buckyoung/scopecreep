using UnityEngine;
using System.Collections;

public class MothershipMovement : MonoBehaviour {
	public float speed = 0.02f;

	private Module navModule;

	void Start() {
		navModule = GameObject.Find("NavigationModule").GetComponent<Module>();
	}

	void Update() {
		if (navModule.activePlayerId > 0) {
			transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				-speed * Input.GetAxis(navModule.activePlayerId + "_AXIS_X")
			);
		}
	}
}