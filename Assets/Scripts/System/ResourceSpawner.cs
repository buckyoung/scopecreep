using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.System {
	public class ResourceSpawner : MonoBehaviour {
		public string resourceName = "SpaceDollar";

		private GameObject mothership;

		void Start() {
			mothership = GameObject.Find("Mothership");

			subscribe();
		}

		/*
		 * User Functions
		 */
		private void subscribe() {
			// Drop resource under ship (DEBUG)
			ButtonEventManager.onDebugButtonDown += (eventObject, playerId) => {
				GameObject resource = (GameObject)Instantiate(
					Resources.Load(resourceName), 
					mothership.transform.position - (mothership.transform.up * 2.0f), 
					Quaternion.identity
				);

				resource.transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);
			};
		}
	}
}