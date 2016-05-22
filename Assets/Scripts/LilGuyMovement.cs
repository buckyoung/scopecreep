using UnityEngine;
using System.Collections;

public class LilGuyMovement : MonoBehaviour {
	public int playerNum = 2;
	public Rigidbody2D rb;
	public float shipSpeed = 10.0f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Must use FixedUpdate when dealing with rigidbody http://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
	void FixedUpdate() {
		var playerMovement = new Vector3(Input.GetAxis("P" + playerNum + "_X_AXIS"), Input.GetAxis("P" + playerNum + "_Y_AXIS"), 0);
		rb.AddRelativeForce(playerMovement * shipSpeed * Time.deltaTime);
	}
}