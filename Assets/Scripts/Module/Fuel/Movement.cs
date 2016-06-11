using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.Fuel { 

	[RequireComponent (typeof (IMoveable))]

	public class Movement : MonoBehaviour {
		private IMoveable moveBehavior;
		private Module fuelModule;

		void Start() {
			fuelModule = GameObject.Find("FuelModule").GetComponent<Module>();
			moveBehavior = GetComponent<IMoveable>();
		}

		void FixedUpdate() {
			if (fuelModule.activePlayerId > 0 && fuelModule.canActivePlayerControlModule) {
				moveBehavior.move();
			}
		}
	}
}