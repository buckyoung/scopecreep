using UnityEngine;
using System.Collections;
using ScopeCreep.System;
using ScopeCreep.Player;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Player.Player))]
	[RequireComponent (typeof (Rigidbody2D))]

	public class MoveablePlayer : MonoBehaviour, IMoveable {
		public float speed = 1.0f;

		private bool isTouchingLadder = false;
		private int id;
		private PointEffector2D gravity;
		private Rigidbody2D rb2D;

		void Start() {
			id = GetComponent<Player.Player>().id;
			rb2D = GetComponent<Rigidbody2D>();

			gravity = GameObject.Find("Gravity").GetComponent<PointEffector2D>(); // For ladder anti-gravity

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
			
		/*
		 * User Functions
		 */

		public void move() {
			var movement = new Vector2(Input.GetAxis(id + "_AXIS_X"), 0);

			if (isTouchingLadder) {
				var scalar = -gravity.forceMagnitude;
				rb2D.AddForce(transform.up * scalar); // Effectively undo gravity when on ladder -- shitty HACK

				movement += new Vector2(0, Input.GetAxis(id + "_AXIS_Y")); // Allow Y movement on ladder
			}

			rb2D.AddRelativeForce(movement * speed * Time.deltaTime);
		}
	}
}