using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Resource;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.LilGuy {

	[RequireComponent (typeof (IDamageable))]
	[RequireComponent (typeof (ResourceHandler))]

	public class GUIHandler : MonoBehaviour {
		private IDamageable damageableBehavior;
		private bool isVisible = false;

		void Start() {
			damageableBehavior = GetComponent<IDamageable>();

			subscribe();
		}

		void OnGUI() {
			if (isVisible) {
				GUI.Label(new Rect(Screen.width - 300, Screen.height - 20, 140, 30), "Health " + damageableBehavior.getHealth());
			}
		}

		/*
		 * User Functions
		 */
		void subscribe() {
			ShipModule.onModuleInteraction += (eventObject, player, isEngaged) => {
				if (eventObject is LilGuy.Module) {
					isVisible = isEngaged;
				}
			};
		}
	}
}