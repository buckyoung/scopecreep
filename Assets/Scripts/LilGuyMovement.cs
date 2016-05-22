using UnityEngine;
using System.Collections;

public class LilGuyMovement : MonoBehaviour {
	public int playerNum = 0;
	public Rigidbody2D rb;
	public float speed = 100.0f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if (playerNum > 0) {
			var playerMovement = new Vector3(Input.GetAxis("P" + playerNum + "_X_AXIS"), Input.GetAxis("P" + playerNum + "_Y_AXIS"), 0);
			rb.AddRelativeForce(playerMovement * speed * Time.deltaTime);
		}
	}
}