using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;
using ScopeCreep.CommonHandlers;

namespace ScopeCreep.Module.LilGuy {

	[RequireComponent (typeof (HealthHandler))]
	[RequireComponent (typeof (ResourceHandler))]

	public class GUIHandler : MonoBehaviour {
		private ResourceHandler resourceHandler;
		private HealthHandler healthHandler;
		private bool isVisible = false;

		void Start() {
			healthHandler = GetComponent<HealthHandler>();
			resourceHandler = GetComponent<ResourceHandler>();

			subscribe();
		}

		void OnGUI() {
			if (isVisible) {
				GUI.Label(new Rect(Screen.width - 150, Screen.height - 50, 140, 30), "   |$| " + resourceHandler.getResource(Resource.ResourceType.SPACEDOLLARS));
				GUI.Label(new Rect(Screen.width - 150, Screen.height - 35, 140, 30), "  Fuel " + resourceHandler.getResource(Resource.ResourceType.FUEL));
				GUI.Label(new Rect(Screen.width - 150, Screen.height - 20, 140, 30), "Health " + healthHandler.gethitPoints());
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