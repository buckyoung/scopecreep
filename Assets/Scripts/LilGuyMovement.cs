using UnityEngine;
using System.Collections;

public class LilGuyMovement : MonoBehaviour {
	public int playerId = 0;
	public Rigidbody2D rb;
	public float speed = 100.0f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if (playerId > 0) {
			var playerMovement = new Vector3(Input.GetAxis(playerId + "_AXIS_X"), Input.GetAxis(playerId + "_AXIS_Y"), 0);
			rb.AddRelativeForce(playerMovement * speed * Time.deltaTime);
		}
	}
}