using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Resource;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.LilGuy { 
	public class ResourceHandler : ResourceManager {
		private float maximum = 25.0f; 

		new void Start() {
			base.Start();

			subscribe();
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {

				Resource.ResourceType type = other.GetComponent<Resource.ICollectible<ResourceType>>().getType();

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
			MoveableLilGuy.onLilGuyMovement += (eventObject, totalForce) => {
				float fuelExpenditure = Mathf.Abs(totalForce/100);
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