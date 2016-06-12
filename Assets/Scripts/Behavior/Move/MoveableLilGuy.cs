using UnityEngine;
using System.Collections;
using ScopeCreep.Resource;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Rigidbody2D))]

	public class MoveableLilGuy : FueledMovement, IMoveable {
		public float speed = 1.0f;

		private Module.LilGuy.Module lilGuyModule;
		private Rigidbody2D rb2D;

		void Start() {
			lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<Module.LilGuy.Module>();
			rb2D = GetComponent<Rigidbody2D>();

			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("PlayerCharacter"), LayerMask.NameToLayer("Childship"));
		}

		/*
		 * User Functions
		 */

		public void move() {
			int activePlayerId = lilGuyModule.activePlayerId;

			Vector2 movement = new Vector2(Input.GetAxis(activePlayerId + "_AXIS_X"), Input.GetAxis(activePlayerId + "_AXIS_Y"));
			Vector2 totalForce = movement * speed * Time.deltaTime;

			rb2D.AddRelativeForce(totalForce);

			throwFueledMovementEvent(this, totalForce.magnitude/100);
		}
	}
}
