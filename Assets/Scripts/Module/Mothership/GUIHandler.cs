using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;
using ScopeCreep.CommonHandlers;

namespace ScopeCreep.Module.Mothership {

	[RequireComponent (typeof (ResourceHandler))]

	public class GUIHandler : MonoBehaviour {
		private ResourceHandler resourceHandler;
		private HealthHandler healthHandler;

		void Start() {
			resourceHandler = this.GetComponent<ResourceHandler>();
			healthHandler = transform.parent.GetComponentInParent<HealthHandler>();
		}

		void OnGUI() {
			GUI.Label(new Rect(Screen.width - 150, 10, 140, 30), "   |$| " + resourceHandler.getResource(Resource.ResourceType.SPACEDOLLARS));
			GUI.Label(new Rect(Screen.width - 150, 25, 140, 30), "  Fuel " + resourceHandler.getResource(Resource.ResourceType.FUEL));
			GUI.Label(new Rect(Screen.width - 150, 40, 140, 30), "Health " + healthHandler.gethitPoints());
		}
	}
}