using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module.Mothership { 
	public class Movement : MonoBehaviour {
		public float speed = 0.02f;

		private Module mothership;
		private bool hasFuel = true;

		// Events
		public delegate void MothershipMovementEvent(Movement eventObject, float totalForce);
		public static event MothershipMovementEvent onMothershipMovement;

		void Start() {
			mothership = GameObject.Find("MothershipModule").GetComponent<Module>();

			subscribe();
		}

		void Update() {
			int activePlayerId = mothership.activePlayerId;

			if (activePlayerId > 0 && mothership.canActivePlayerControlModule && hasFuel) {
				float totalForce = -speed * Input.GetAxis(activePlayerId + "_AXIS_X");

				transform.RotateAround(
					Vector3.zero, 
					Vector3.forward, 
					totalForce
				);

				onMothershipMovement(this, totalForce);
			}
		}

		/*
		 * User Functions
		 */
		private void subscribe() {
			ResourceHandler.onFuelEvent += (eventObject, hasFuel) => {
				if (eventObject.gameObject.name == "MothershipModule") {
					this.hasFuel = hasFuel;
				}
			};
		}
	}
}