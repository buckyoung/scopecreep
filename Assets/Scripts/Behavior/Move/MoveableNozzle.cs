using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Rigidbody2D))]

	public class MoveableNozzle : MonoBehaviour, IMoveable {
		public float speed = 1.0f;

		private Module.Fuel.Module fuelModule;
		private Rigidbody2D rb2D;

		void Start() {
			fuelModule = GameObject.Find("FuelModule").GetComponent<Module.Fuel.Module>();
			rb2D = GetComponent<Rigidbody2D>();
		}

		/*
		 * User Functions
		 */

		public void move() {
			int activePlayerId = fuelModule.activePlayerId;

			Vector2 movement = new Vector2(Input.GetAxis(activePlayerId + "_AXIS_X"), Input.GetAxis(activePlayerId + "_AXIS_Y"));
			Vector2 totalForce = movement * speed * Time.deltaTime;

			rb2D.AddRelativeForce(totalForce);
		}
	}
}
