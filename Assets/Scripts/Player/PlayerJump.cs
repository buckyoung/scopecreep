using UnityEngine;
using System.Collections;
using ScopeCreep.System;

namespace ScopeCreep.Player {

	[RequireComponent (typeof (Player))]
	[RequireComponent (typeof (Rigidbody2D))]

	public class PlayerJump : MonoBehaviour {
		public int jumpHeight = 30;

		private bool canJump = true;
		private int id;
		private Rigidbody2D rb2D;

		void Start() {
			id = GetComponent<Player>().id;
			rb2D = GetComponent<Rigidbody2D>();

			subscribe();
		}

		void OnCollisionEnter2D(Collision2D col) {
			if ( col.gameObject.CompareTag("Ground") ) {
				canJump = true;
			}
		}

		/*
		 * User Functions
		 */

		void subscribe() {
			// The player wants to jump
			ButtonEventManager.onAButtonDown += (eventObject, playerId) => {
				if (id == playerId && canJump) {
					rb2D.AddRelativeForce(new Vector2(0, jumpHeight) * Time.deltaTime, ForceMode2D.Impulse);
					canJump = false;
				}
			};
		}
	}
}