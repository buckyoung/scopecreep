using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Player {
	public class Movement : MonoBehaviour {
		public int playerId = 1;

		private bool canJump = true;
		private bool isAtModule = false;
		private bool isTouchingLadder = false;
		private float speed = 150.0f;
		private int jumpHeight = 30;
		private Rigidbody2D rb2D;
		private PointEffector2D planetPointEffector2D;
		
		void Start() {
			planetPointEffector2D = GameObject.Find("Planet").GetComponent<PointEffector2D>();
			rb2D = GetComponent<Rigidbody2D>();

			// Ignore collisions between PlayerCharacters
			Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);

			subscribe();
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
					rb2D.AddForce(transform.up * scalar); // Effectively undo gravity when on ladder

					movement += new Vector2(0, Input.GetAxis(playerId + "_AXIS_Y")); // Allow Y movement on ladder
				}

				rb2D.AddRelativeForce(movement * speed * Time.deltaTime);

				if (Input.GetButtonDown(playerId + "_BTN_A") && canJump) {
					rb2D.AddRelativeForce(new Vector2(0, jumpHeight) * Time.deltaTime, ForceMode2D.Impulse);
					canJump = false;
				}
			}
		}

		/*
		 * User Functions
		 */
		void subscribe() {
			Module.ShipModule.onModuleInteraction += (eventObject, playerId, isEngaged) => {
				if (this.playerId == playerId) {
					this.isAtModule = isEngaged;
				}
			};
		}
	}
}