using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module.Mothership {
	public class GUIHandler : MonoBehaviour {
		private ResourceHandler resourceHandler;
		private bool isVisible = false;

		void Start() {
			resourceHandler = GetComponent<ResourceHandler>();
		}

		void OnGUI() {
			GUI.Label(new Rect(Screen.width - 150, 10, 140, 30), "|$paceDollars|: " + resourceHandler.getSpaceDollars()); 
		}
	}
}