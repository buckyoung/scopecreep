using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module.Mothership { 
	public class ResourceHandler : ResourceManager{
		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {

				base.addResource(other.GetComponent<Collectible.Collectible>().type, 1.0f);

				Destroy(other.gameObject);
			}
		}
	}
}