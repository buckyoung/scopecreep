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
				GUI.Label(new Rect(Screen.width - 150, Screen.height - 30, 140, 30), "|$| " + resourceHandler.getSpaceDollars() + "/" + resourceHandler.getMaximum()); 
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