using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Resource;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.Mothership { 
	public class ResourceHandler : ResourceManager{
		new void Start() {
			base.Start();

//			subscribe();
		}

		/*
		 * User Functions
		 */


		// MOTHERSHIP FUEL BURN TODO BUCK
//		private void subscribe() {
//			MoveableMothership.onMothershipMovement += (eventObject, totalForce) => {
//				float fuelExpenditure = Mathf.Abs(totalForce/10);
//				float currentFuel = cargoHold[Resource.ResourceType.FUEL];
//
//				if (currentFuel - fuelExpenditure <= 0) {
//					cargoHold[Resource.ResourceType.FUEL] = 0;
//					throwFuelEvent(this);
//				} else {
//					cargoHold[Resource.ResourceType.FUEL] -= fuelExpenditure;
//				}
//			};
//		}
	}
}