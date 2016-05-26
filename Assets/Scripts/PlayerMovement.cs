using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public bool isAtModule = false;
	public int jumpHeight = 30;
	public int playerId = 1;
	public Rigidbody2D rigidbody2D;
	public float speed = 150.0f;

	private bool canJump = true;
	
	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();

		// Ignore collisions between PlayerCharacters
		Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
	}

	void FixedUpdate() {
		if (!isAtModule) {
			var movement = new Vector2(Input.GetAxis(playerId + "_AXIS_X"), 0);
			rigidbody2D.AddRelativeForce(movement * speed * Time.deltaTime);

			if (Input.GetButtonDown(playerId + "_BTN_A") && canJump) {
				rigidbody2D.AddRelativeForce(new Vector2(0, jumpHeight) * Time.deltaTime, ForceMode2D.Impulse);
				canJump = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag("Ground")) {
			canJump = true;
		}
	}
}