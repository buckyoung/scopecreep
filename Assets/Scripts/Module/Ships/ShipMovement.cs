using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;
using ScopeCreep.Resource;

namespace ScopeCreep.Module { 

	[RequireComponent (typeof (IMoveable))]

	public class ShipMovement : MonoBehaviour {
		private IMoveable moveBehavior;
		private ShipModule module;
		private IContainer fuelContainer;

		void Start() {
			// Used to find "MothershipModule" or "LilGuyModule"
			// Thus, this script must be placed on the "Mothership" or "LilGuy" Game Object
			// This is brittle TODO BUCK (forces invisible name dependencies on object + module)
			module = GameObject.Find(gameObject.name + "Module").GetComponent<ShipModule>(); 

			moveBehavior = GetComponent<IMoveable>();
			fuelContainer = GetComponentInChildren<ICargoHold>().getContainer(ResourceType.FUEL);
		}

		void FixedUpdate() {
			if (module.activePlayerId > 0 && module.canActivePlayerControlModule && !fuelContainer.isEmpty()) {
				moveBehavior.move();
			}
		}
	}
}