using UnityEngine;
using System.Collections;

public class LilGuyMovement : MonoBehaviour {

	public int playerNum = 1;
	public float shipSpeed = 10.0f;

	void Update() {
		var movementVector = new Vector3(Input.GetAxis("P" + playerNum + "_X_AXIS"), Input.GetAxis("P" + playerNum + "_Y_AXIS"), 0);
		transform.localPosition += movementVector * shipSpeed * Time.deltaTime;
	}
}