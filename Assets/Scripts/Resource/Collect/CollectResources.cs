using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {

	[RequireComponent (typeof(ICargoHold))]

	public class CollectResources : MonoBehaviour, ICollect {
		private ICargoHold cargoHold;

		void Start() {
			cargoHold = gameObject.GetComponent<ICargoHold>();
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {
				ICollectible collectible = other.GetComponent<ICollectible>();

				if (collect(collectible)) {
					Destroy(other.gameObject);	
				}
			}
		}

		/*
		 * User Functions
		 */

		// Note: Will collect a resource if any bit of that resource can fit in the container 
		public bool collect(ICollectible collectible) {
			IContainer container = cargoHold.getContainer(collectible.getType());

			if (container.isFull()) { 
				return false;
			}

			container.add(collectible.getAmount());

			return true;
		}
	}
}