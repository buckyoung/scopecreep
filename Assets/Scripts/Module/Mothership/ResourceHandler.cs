﻿using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Resource;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.Mothership { 
	public class ResourceHandler : ResourceManager{
		new void Start() {
			base.Start();
			base.addResource(Resource.ResourceType.FUEL, 500.0f); // Starting fuel in mothership

			subscribe();
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {
				base.addResource(other.GetComponent<Resource.Collectible>().type, 1.0f);

				Destroy(other.gameObject);
			}
		}

		/*
		 * User Functions
		 */

		private void subscribe() {
			MoveableMothership.onMothershipMovement += (eventObject, totalForce) => {
				float fuelExpenditure = Mathf.Abs(totalForce/10);
				float currentFuel = cargoHold[Resource.ResourceType.FUEL];

				if (currentFuel - fuelExpenditure <= 0) {
					cargoHold[Resource.ResourceType.FUEL] = 0;
					throwFuelEvent(this);
				} else {
					cargoHold[Resource.ResourceType.FUEL] -= fuelExpenditure;
				}
			};
		}
	}
}