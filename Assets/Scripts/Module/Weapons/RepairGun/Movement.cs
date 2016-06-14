using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.RepairGun { 
	public class Movement : MonoBehaviour {
		public float speed = 0.02f;
		public float maxRotation = 55.0f;

		private float barrelPosition;
		private RepairGun.Module repairGunModule;

		void Start() {
			repairGunModule = transform.parent.GetComponentInChildren<Module>();
			barrelPosition = 0.0f;
		}

		void Update() {
			if (repairGunModule.activePlayerId == 0) return;
				
			float totalForce = speed * Input.GetAxis(repairGunModule.activePlayerId + "_AXIS_X");

			if ((totalForce < 0 && barrelPosition >= -maxRotation) 
				|| (totalForce > 0 && barrelPosition <= maxRotation)) {				
				barrelPosition += totalForce;
				transform.Rotate (
					0,
					0,
					totalForce
				);
			}
		}
	}
}
