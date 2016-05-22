using UnityEngine;
using System.Collections;

public class MothershipMovement : MonoBehaviour {
	public int playerNum = 0;
	public float speed = 0.02f;

	void Update() {
		if (playerNum > 0) {
			transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				-speed * Input.GetAxis("P" + playerNum + "_X_AXIS")
			);
		}
	}
}