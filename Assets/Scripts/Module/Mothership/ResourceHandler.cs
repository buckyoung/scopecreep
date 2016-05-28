using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module.Mothership { 
	public class ResourceHandler : ResourceManager, IResourceHandler {
		private float spaceDollars = 0;

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {

				ResourceManager.collect(this, other.GetComponent<Collectible.Collectible>());

				Destroy(other.gameObject);
			}
		}

		/*
		 * User Functions
		 */
		public void addSpaceDollars(float amount) {
			spaceDollars += amount;
		}

		public float getSpaceDollars() {
			return spaceDollars;
		}
	}
}