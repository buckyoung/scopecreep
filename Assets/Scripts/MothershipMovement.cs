using UnityEngine;
using System.Collections;

public class MothershipMovement : MonoBehaviour {
	public float speed = 0.02f;

	private NavigationModule navigationModule;

	void Start() {
		navigationModule = GameObject.Find("NavigationModule").GetComponent<Module>();
	}

	void Update() {
		int playerId = navigationModule.activePlayerId;

		if (playerId > 0) {
			transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				-speed * Input.GetAxis(playerId + "_AXIS_X")
			);
		}
	}
}