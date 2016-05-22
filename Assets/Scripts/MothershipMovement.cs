using UnityEngine;
using System.Collections;

public class MothershipMovement : MonoBehaviour {
	public int playerNum = 1;

	public float speed = 1.0f;

	void Update() {
		var move = new Vector3(Input.GetAxis("P" + playerNum + "_X_AXIS"), Input.GetAxis("P" + playerNum + "_Y_AXIS"), 0);
		transform.position += move * speed * Time.deltaTime;
	}
}