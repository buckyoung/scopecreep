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
				GUI.Label(new Rect(300, 370, 140, 100), "resources: " + resourceHandler.getTotal() + "/" + resourceHandler.getMaximum()); 
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