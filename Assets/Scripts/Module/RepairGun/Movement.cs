using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.RepairGun { 
	public class Movement : MonoBehaviour {
		public float speed = 0.02f;

		private RepairGun.Module repairGunModule;

		void Start() {
			repairGunModule = transform.parent.GetComponentInChildren<Module>();
		}

		/*
		 * User Functions
		 */

		public void Update(){
			if (repairGunModule.activePlayerId == 0) return;
				
			float totalForce = -speed * Input.GetAxis(repairGunModule.activePlayerId + "_AXIS_X");

			transform.Rotate(
				0,
				0,
				totalForce
			);
		}
	}
}