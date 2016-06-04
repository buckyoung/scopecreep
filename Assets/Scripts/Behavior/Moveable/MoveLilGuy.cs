using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Rigidbody2D))]

	public class MoveLilGuy : MonoBehaviour, IMoveable {
		public float speed = 1.0f;

		private Module.LilGuy.Module lilGuyModule;
		private Rigidbody2D rb2D;

		// Events
		public delegate void LilGuyMovementEvent(MoveLilGuy eventObject, float totalForce);
		public static event LilGuyMovementEvent onLilGuyMovement;

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

			if (onLilGuyMovement != null) onLilGuyMovement(this, totalForce.magnitude);
		}
	}
}
