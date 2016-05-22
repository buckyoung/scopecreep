using UnityEngine;
using System.Collections;

public class MothershipMovement : MonoBehaviour {
	public int playerNum = 1;
	public float speed = 0.02f;

	void Update() {
		transform.RotateAround(
			Vector3.zero, 
			Vector3.forward, 
			-speed * Input.GetAxis("P" + playerNum + "_X_AXIS")
		);
	}
}