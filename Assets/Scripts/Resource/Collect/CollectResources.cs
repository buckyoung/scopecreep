using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {

	[RequireComponent (typeof(ICargoHold))]

	public class CollectResources : MonoBehaviour, ICollect<ResourceType> {
		private ICargoHold cargoHold;

		void Start() {
			cargoHold = gameObject.GetComponent<ICargoHold>();
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {
				ICollectible<ResourceType> collectible = other.GetComponent<ICollectible<ResourceType>>();

				if (collect(collectible)) {
					Destroy(other.gameObject);	
				}
			}
		}

		/*
		 * User Functions
		 */

		// Note: Will collect a resource if any bit of that resource can fit in the container 
		public bool collect(ICollectible<ResourceType> collectible) {
			IContainer container = cargoHold.getContainer(collectible.getType());

			if (container.isFull()) { 
				return false;
			}

			container.add(collectible.getAmount());

			return true;
		}
	}
}