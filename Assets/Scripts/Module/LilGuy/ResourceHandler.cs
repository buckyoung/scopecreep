using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module.LilGuy { 
	public class ResourceHandler : ResourceManager {
		private float maximum = 1.0f;

		new void Start() {
			base.Start();

			subscribe();
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {

				Resource.ResourceType type = other.GetComponent<Resource>().type;

				if (cargoHold[type] < maximum) {
					base.addResource(type, 1.0f);

					Destroy(other.gameObject);
				}
			}
		}

		/*
		 * User Functions
		 */
		public float getMaximum() {
			return maximum;
		}

		private void subscribe() {
			Movement.onLilGuyMovement += (eventObject, totalForce) => {
				float fuelExpenditure = Mathf.Abs(totalForce/100);
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