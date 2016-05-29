using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module.LilGuy { 
	public class ResourceHandler : ResourceManager {
		private float maximum = 10.0f;

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
	}
}