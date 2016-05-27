using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int playerId = 1;

	private bool canJump = true;
	private bool isAtModule = false;
	private bool isTouchingLadder = false;
	private float speed = 150.0f;
	private int jumpHeight = 30;
	private Rigidbody2D rigidbody2D;
	private PointEffector2D planetPointEffector2D;
	
	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();
		planetPointEffector2D = GameObject.Find("Planet").GetComponent<PointEffector2D>();

		// Ignore collisions between PlayerCharacters
		Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);

		subscribeToModules();
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
				var scalar = -planetPointEffector2D.forceMagnitude;
				rigidbody2D.AddForce(Vector2.up * scalar); // Effectively undo gravity when on ladder

				movement += new Vector2(0, Input.GetAxis(playerId + "_AXIS_Y")); // Allow Y movement on ladder
			}

			rigidbody2D.AddRelativeForce(movement * speed * Time.deltaTime);

			if (Input.GetButtonDown(playerId + "_BTN_A") && canJump) {
				rigidbody2D.AddRelativeForce(new Vector2(0, jumpHeight) * Time.deltaTime, ForceMode2D.Impulse);
				canJump = false;
			}
		}
	}

	/*
	 * User Functions
	 */
	void subscribeToModules() {
		LilGuyModule lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<LilGuyModule>();
		lilGuyModule.playerAtModuleEvent += (eventObject, args) => {
			if (playerId == args.playerId) {
				isAtModule = args.isAtModule;
			}
		};

		MothershipModule mothershipModule = GameObject.Find("MothershipModule").GetComponent<MothershipModule>();
		mothershipModule.playerAtModuleEvent += (eventObject, args) => {
			if (playerId == args.playerId) {
				isAtModule = args.isAtModule;
			}
		};
	}
}