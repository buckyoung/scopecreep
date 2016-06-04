using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Rigidbody2D))]

	public class MoveLilGuy : MonoBehaviour, IMoveable {
		public float speed = 1.0f;

		private Rigidbody2D rb2D;
		private Module.LilGuy.Module lilGuyModule;

		// Events
		public delegate void LilGuyMovementEvent(MoveLilGuy eventObject, float totalForce);
		public static event LilGuyMovementEvent onLilGuyMovement;

		void Start() {
			rb2D = GetComponent<Rigidbody2D>();
			lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<Module.LilGuy.Module>();

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

			onLilGuyMovement(this, totalForce.magnitude);
		}
	}
}
