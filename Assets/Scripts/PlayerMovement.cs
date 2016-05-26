using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public bool isAtModule = false;
	public int playerId = 1;

	private bool canJump = true;
	private bool isTouchingLadder = false;
	private float speed = 150.0f;
	private int jumpHeight = 30;
	private Rigidbody2D rigidbody2D;
	
	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();

		// Ignore collisions between PlayerCharacters
		Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Ladder") {
			isTouchingLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Ladder") {
			isTouchingLadder = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag("Ground")) {
			canJump = true;
		}
	}

	void FixedUpdate() {
		if (!isAtModule) {
			var movement = new Vector2(Input.GetAxis(playerId + "_AXIS_X"), 0);

			if (isTouchingLadder) {
				// TODO turn off gravity
				movement += new Vector2(0, Input.GetAxis(playerId + "_AXIS_Y"));
			}

			Debug.Log(movement);

			rigidbody2D.AddRelativeForce(movement * speed * Time.deltaTime);

			if (Input.GetButtonDown(playerId + "_BTN_A") && canJump) {
				rigidbody2D.AddRelativeForce(new Vector2(0, jumpHeight) * Time.deltaTime, ForceMode2D.Impulse);
				canJump = false;
			}
		}
	}
}