using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module.Mothership { 
	public class ResourceHandler : ResourceManager{
		new void Start() {
			base.Start();
			base.addResource(Resource.ResourceType.FUEL, 100.0f);

			subscribe();
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {

				base.addResource(other.GetComponent<Resource>().type, 1.0f);

				Destroy(other.gameObject);
			}
		}


		/*
		 * User Functions
		 */

		private void subscribe() {
			Movement.onMothershipMovement += (eventObject, totalForce) => {
				float fuelExpenditure = Mathf.Abs(totalForce/10);
				float currentFuel = cargoHold[Resource.ResourceType.FUEL];

				if (currentFuel - fuelExpenditure <= 0) {
					cargoHold[Resource.ResourceType.FUEL] = 0;
					throwOutOfFuelEvent(this);
				} else {
					cargoHold[Resource.ResourceType.FUEL] -= fuelExpenditure;
				}
			};
		}
	}
}