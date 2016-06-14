using UnityEngine;
using System.Collections;
using ScopeCreep.System;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.RepairGun { 
	public class BarrelControl : MonoBehaviour {
		private RepairGun.Module repairGunModule;
		private Behavior.IShoot shootBehavior;

		void Start() {
			repairGunModule = transform.parent.parent.GetComponentInChildren<Module>();
			shootBehavior = this.GetComponent<Behavior.IShoot>();
			subscribe();
		}

		/*
		 * User Functions
		 */

		void subscribe() {
			// The player wants to jump
			ButtonEventManager.onAButtonDown += (eventObject, playerId) => {
				if (playerId == repairGunModule.activePlayerId) {
					shootBehavior.shoot();
				}
			};
		}
	}
}
