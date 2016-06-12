using UnityEngine;
using System.Collections;

namespace ScopeCreep.Module {
	public class ShipGUI : MonoBehaviour {
		protected bool shouldDraw = false;

		protected void Start() {
			subscribe();
		}

		/*
		 * User Functions
		 */

		private void subscribe() {
			ShipModule.onModuleInteraction += (eventObject, player, isEngaged) => {
				if (eventObject is Mothership.Module && gameObject.name == "Mothership") { // String comparison is very brittle TODO BUCK
					shouldDraw = isEngaged;
				}

				if (eventObject is LilGuy.Module && gameObject.name == "LilGuy") { // String comparison is very brittle TODO BUCK
					shouldDraw = isEngaged;
				}
			};
		}
	}
}
