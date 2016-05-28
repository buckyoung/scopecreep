using UnityEngine;
using System.Collections;
using ScopeCreep;

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
				int offset = 35;
				foreach(Collectible.Collectible.CollectibleType type in ((Collectible.Collectible.CollectibleType[]) Collectible.Collectible.CollectibleType.GetValues(typeof(Collectible.Collectible.CollectibleType)))) {
					GUI.Label(new Rect(Screen.width - 150, Screen.height - offset, 140, 30), "|$| " + resourceHandler.getResource(type)); 
					offset -= 15;
				}
			}
		}

		/*
		 * User Functions
		 */
		void subscribe() {
			LilGuy.onLilGuyInteraction += (eventObject, isEngaged) => {
				isVisible = isEngaged;
			};
		}
	}
}