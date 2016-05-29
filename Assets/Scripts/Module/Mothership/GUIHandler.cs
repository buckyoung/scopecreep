using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module.Mothership {
	public class GUIHandler : MonoBehaviour {
		private ResourceHandler resourceHandler;

		void Start() {
			resourceHandler = GetComponent<ResourceHandler>();
		}

		void OnGUI() {
			GUI.Label(new Rect(Screen.width - 150, 10, 140, 30), "   |$| " + resourceHandler.getResource(Resource.ResourceType.SPACEDOLLARS));
			GUI.Label(new Rect(Screen.width - 150, 25, 140, 30), "Fuel " + resourceHandler.getResource(Resource.ResourceType.FUEL));
		}
	}
}