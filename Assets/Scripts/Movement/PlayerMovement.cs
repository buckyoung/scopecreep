using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public bool isAtModule = false;
	public int playerId = 1;
	public Rigidbody2D rb;
	public float speed = 150.0f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();

		// Ignore collisions between PlayerCharacters
		Physics2D.IgnoreLayerCollision(8, 8);
	}

	void FixedUpdate() {
		if (!isAtModule) {
			var movement = new Vector2(Input.GetAxis(playerId + "_AXIS_X"), Input.GetAxis(playerId + "_AXIS_Y"));
			rb.AddRelativeForce(movement * speed * Time.deltaTime);
		}
	}
}