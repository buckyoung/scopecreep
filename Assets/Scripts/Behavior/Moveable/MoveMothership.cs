using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public class MoveMothership : MonoBehaviour, IMoveable {
		public float speed = 0.02f;

		private Module.Mothership.Module mothershipModule;
		private GameObject scaffold;

		// Events
		public delegate void MothershipMovementEvent(MoveMothership eventObject, float totalForce);
		public static event MothershipMovementEvent onMothershipMovement;

		void Start() {
			mothershipModule = GameObject.Find("MothershipModule").GetComponent<Module.Mothership.Module>();
			scaffold = GameObject.Find("Scaffold");
		}

		/*
		 * User Functions
		 */

		public void move() {
			float totalForce = -speed * Input.GetAxis(mothershipModule.activePlayerId + "_AXIS_X");

			scaffold.transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				totalForce
			);

			if (onMothershipMovement != null) onMothershipMovement(this, totalForce);
		}
	}
}