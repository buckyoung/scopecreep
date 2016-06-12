using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.System {
	public class ResourceSpawner : MonoBehaviour {
		private string[] resourceName = new string[4];

		private GameObject mothership;

		void Start() {
			mothership = GameObject.Find("Mothership");

			// Hardcoded Debug
			resourceName[0] = "Collectible/Ammo";
			resourceName[1] = "Collectible/Fuel";
			resourceName[2] = "Collectible/SpaceDollar";
			resourceName[3] = "Collectible/Thiamin";
			// End Debug

			subscribe();
		}

		/*
		 * User Functions
		 */
		private void subscribe() {
			// Drop resource under ship (DEBUG)
			ButtonEventManager.onDebugButtonDown += (eventObject, playerId) => {

				for (int i = 0; i < 10; i++) { // Make 10 resources on 1 press

					string name = resourceName[Mathf.RoundToInt(Random.value * 3)];
					Vector3 position = mothership.transform.position - (mothership.transform.up * 3.0f);
					position.z = 20;

					GameObject resource = (GameObject)Instantiate(
						Resources.Load(name), 
						position,
						Quaternion.identity
					);

					resource.transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);

				}
			};
		}
	}
}