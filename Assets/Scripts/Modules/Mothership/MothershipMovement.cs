using UnityEngine;
using System.Collections;

public class MothershipMovement : MonoBehaviour {
	public float speed = 0.02f;

	private MothershipModule mothershipModule;

	void Start() {
		mothershipModule = GameObject.Find("MothershipModule").GetComponent<MothershipModule>();
	}

	void Update() {
		int activePlayerId = mothershipModule.activePlayerId;

		if (activePlayerId > 0) {
			transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				-speed * Input.GetAxis(activePlayerId + "_AXIS_X")
			);
		}
	}
}