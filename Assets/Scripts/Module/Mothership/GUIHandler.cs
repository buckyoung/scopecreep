using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Collectible;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.Mothership {

	[RequireComponent (typeof (IDamageable))]
	[RequireComponent (typeof (ResourceHandler))]

	public class GUIHandler : MonoBehaviour {
		private IDamageable damageableBehavior;
		private ResourceHandler resourceHandler;

		void Start() {
			damageableBehavior = GetComponent<IDamageable>();
			resourceHandler = GetComponent<ResourceHandler>();
		}

		void OnGUI() {
			GUI.Label(new Rect(Screen.width - 150, 10, 140, 30), "   |$| " + resourceHandler.getResource(Resource.ResourceType.SPACEDOLLARS));
			GUI.Label(new Rect(Screen.width - 150, 25, 140, 30), "  Fuel " + resourceHandler.getResource(Resource.ResourceType.FUEL));
			GUI.Label(new Rect(Screen.width - 150, 40, 140, 30), "Health " + damageableBehavior.getMetric());
		}
	}
}