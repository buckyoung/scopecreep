using UnityEngine;
using System.Collections;
using ScopeCreep.Module;

namespace ScopeCreep.System {

	[RequireComponent (typeof (Camera))]

	public class Minimap : MonoBehaviour {
		private Camera cam;

		void Start () {
			cam = gameObject.GetComponent<Camera>();

			subscribe();
		}

		private void subscribe() {
			// Only enable minimap when mothership nav module is engaged
			ShipModule.onModuleInteraction += (eventObject, player, isEngaged) => {
				if (eventObject is Module.Mothership.Module) {
					cam.enabled = isEngaged;
				}
			};
		}
	}
}