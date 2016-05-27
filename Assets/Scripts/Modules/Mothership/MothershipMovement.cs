using UnityEngine;
using System.Collections;

public class MothershipMovement : MonoBehaviour {
	public float speed = 0.02f;

	private MothershipModule mothershipModule;

	void Start() {
		mothershipModule = GameObject.Find("MothershipModule").GetComponent<MothershipModule>();
	}

	void Update() {
		int playerId = mothershipModule.activePlayerId;

		if (playerId > 0) {
			transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				-speed * Input.GetAxis(playerId + "_AXIS_X")
			);
		}
	}
}