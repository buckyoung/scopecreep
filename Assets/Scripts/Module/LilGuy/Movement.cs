using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.System;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.LilGuy { 

	[RequireComponent (typeof (BoxCollider2D))]
	[RequireComponent (typeof (IMoveable))]

	public class Movement : MonoBehaviour {
		private BoxCollider2D boxCollider2D;
		private Module lilGuyModule;
		private BoxCollider2D msBottomBoxCollider2D;
		private bool hasFuel = true;
		private IMoveable moveBehavior;

		void Start() {
			boxCollider2D = GetComponent<BoxCollider2D>();
			lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<Module>();
			msBottomBoxCollider2D = GameObject.Find("MSBottom").GetComponent<BoxCollider2D>();
			moveBehavior = GetComponent<IMoveable>();

			subscribe();
		}

		void FixedUpdate() {
			if (lilGuyModule.activePlayerId > 0 && lilGuyModule.canActivePlayerControlModule && hasFuel) {
				moveBehavior.move();
			}
		}

		/*
		 * User Functions
		 */

		public IEnumerator playAnimation_shipEnter() {
			var speed = 2.0f;

			lilGuyModule.canActivePlayerControlModule = false; // Player has no control of childship during animation
			Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership during animation

			yield return StartCoroutine( gameObject.moveToObjectWithSpeed2D(lilGuyModule.gameObject, speed) );

			lilGuyModule.canActivePlayerDisengage = true; // Allow player to exit the childship
			lilGuyModule.performDisengage(lilGuyModule.activePlayerId); // Exit the childship automatically
		}

		public IEnumerator playAnimation_shipExit() {
			var time = 0.2f;
			var endPosition = transform.position - (transform.up * 2.0f);

			lilGuyModule.canActivePlayerControlModule = false; // Player has no control of childship during animation
			Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership during animation

			yield return StartCoroutine( gameObject.moveInSeconds2D(endPosition, time) ); // Childship exits mothership over T seconds

			lilGuyModule.canActivePlayerControlModule = true; // Return childship control to player
			Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, false); // Reenable collisions with mothership
		}

		private void subscribe() {
			ResourceHandler.onFuelEvent += (eventObject, hasFuel) => {
				if (eventObject.gameObject.name == "LilGuy") {
					this.hasFuel = hasFuel;
				}
			};
		}
	}
}