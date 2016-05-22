using UnityEngine;
using System.Collections;

public class LilGuyMovement : MonoBehaviour {

	public int playerNum = 2;
	public float shipSpeed = 10.0f;

	public Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Must use FixedUpdate when dealing with rigidbody http://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
	void FixedUpdate() {
		var movementVector = new Vector3(Input.GetAxis("P" + playerNum + "_X_AXIS"), Input.GetAxis("P" + playerNum + "_Y_AXIS"), 0);
		rb.AddForce(movementVector * shipSpeed * Time.deltaTime);
	}
}