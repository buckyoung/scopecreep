using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module.Mothership {
	public class GUIHandler : MonoBehaviour {
		private ResourceHandler resourceHandler;

		void Start() {
			resourceHandler = GetComponent<ResourceHandler>();
		}

		void OnGUI() {
			int offset = 10;
			foreach(Collectible.Collectible.CollectibleType type in ((Collectible.Collectible.CollectibleType[]) Collectible.Collectible.CollectibleType.GetValues(typeof(Collectible.Collectible.CollectibleType)))) {
				GUI.Label(new Rect(Screen.width - 150, offset, 140, 30), "|$| " + resourceHandler.getResource(type)); 
				offset += 15;
			}
		}
	}
}