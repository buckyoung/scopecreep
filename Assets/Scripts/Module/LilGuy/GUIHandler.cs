using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module.LilGuy {
	public class GUIHandler : MonoBehaviour {
		private ResourceHandler resourceHandler;
		private bool isVisible = false;

		void Start() {
			resourceHandler = GetComponent<ResourceHandler>();

			subscribe();
		}

		void OnGUI() {
			if (isVisible) {
				GUI.Label(new Rect(Screen.width - 150, Screen.height - 50, 140, 30), "   |$| " + resourceHandler.getResource(Resource.ResourceType.SPACEDOLLARS));
				GUI.Label(new Rect(Screen.width - 150, Screen.height - 35, 140, 30), "Fuel " + resourceHandler.getResource(Resource.ResourceType.FUEL));
			}
		}

		/*
		 * User Functions
		 */
		void subscribe() {
			ShipModule.onModuleInteraction += (eventObject, player, isEngaged) => {
				if (eventObject is LilGuy.Module) {
					isVisible = isEngaged;
				}
			};
		}
	}
}