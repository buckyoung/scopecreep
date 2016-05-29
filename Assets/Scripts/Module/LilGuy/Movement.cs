using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.System;

namespace ScopeCreep.Module.LilGuy { 
	public class Movement : MonoBehaviour {
		public Rigidbody2D rb2D;
		public float speed = 100.0f;

		private BoxCollider2D boxCollider2D;
		private LilGuy lilGuy;
		private BoxCollider2D msBottomBoxCollider2D;
		
		void Start() {
			boxCollider2D = GetComponent<BoxCollider2D>();
			lilGuy = GameObject.Find("LilGuyModule").GetComponent<LilGuy>();
			msBottomBoxCollider2D = GameObject.Find("MSBottom").GetComponent<BoxCollider2D>();
			rb2D = GetComponent<Rigidbody2D>();

			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("PlayerCharacter"), LayerMask.NameToLayer("Childship"));
		}

		void FixedUpdate() {
			int activePlayerId = lilGuy.activePlayerId;

			if (activePlayerId > 0 && lilGuy.canActivePlayerControlModule) {
				var movement = new Vector2(Input.GetAxis(activePlayerId + "_AXIS_X"), Input.GetAxis(activePlayerId + "_AXIS_Y"));
				rb2D.AddRelativeForce(movement * speed * Time.deltaTime);
			}
		}

		/*
		 * User Functions
		 */

		public IEnumerator playAnimation_shipEnter() {
			var speed = 2.0f;

			lilGuy.canActivePlayerControlModule = false; // Player has no control of childship during animation
			Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership during animation

			yield return StartCoroutine( gameObject.moveToObjectWithSpeed2D(lilGuy.gameObject, speed) );

			lilGuy.canActivePlayerDisengage = true; // Allow player to exit the childship
			lilGuy.disengage(lilGuy.activePlayerId); // Exit the childship automatically
		}

		public IEnumerator playAnimation_shipExit() {
			var time = 0.2f;
			var endPosition = transform.position - (transform.up * 2.0f);

			lilGuy.canActivePlayerControlModule = false; // Player has no control of childship during animation
			Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership during animation

			yield return StartCoroutine( gameObject.moveInSeconds2D(endPosition, time) ); // Childship exits mothership over T seconds

			lilGuy.canActivePlayerControlModule = true; // Return childship control to player
			Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, false); // Reenable collisions with mothership
		}
	}
}