using UnityEngine;
using System.Collections;
namespace ScopeCreep.Behavior {
	public class MoveableMothership : FueledMovement, IMoveable {
		public float speed = 0.02f;

		private GameObject scaffold;
		private Module.Mothership.Module mothershipModule;

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

			throwFueledMovementEvent(this, Mathf.Abs(totalForce/10));
		}
	}
}