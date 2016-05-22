using UnityEngine;
using System.Collections;

public class MothershipMovement : MonoBehaviour {
	public int playerNum = 1;
	public float shipSpeed = 0.02f;

	void Update() {
		transform.RotateAround(
			Vector3.zero, 
			Vector3.forward, 
			-shipSpeed * Input.GetAxis("P" + playerNum + "_X_AXIS")
		);
	}
}