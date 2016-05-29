using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module.Mothership { 
	public class ResourceHandler : ResourceManager{
		new void Start() {
			base.Start();
			base.addResource(Resource.ResourceType.FUEL, 100.0f);
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Collectible") {

				base.addResource(other.GetComponent<Resource>().type, 1.0f);

				Destroy(other.gameObject);
			}
		}
	}
}