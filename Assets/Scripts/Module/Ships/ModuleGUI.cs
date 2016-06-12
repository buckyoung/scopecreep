using UnityEngine;
using System.Collections;

namespace ScopeCreep.Module {
	public abstract class ModuleGUI : MonoBehaviour {
		protected bool shouldDraw = false;

		protected void Start() {
			subscribe();
		}

		/*
		 * User Functions
		 */

		private void subscribe() {
			ShipModule.onModuleInteraction += (eventObject, player, isEngaged) => {
				if (this == null) { return; } // When lilguy dies, for instance

				// TODO BUCK: This sucks -- brittle & performance concern
				// Though, it is called relatively infrequently
				string thisModuleName = this.transform.parent.gameObject.name + "Module";
				string eventModuleName = eventObject.gameObject.name;

				if (thisModuleName == eventModuleName) {
					shouldDraw = isEngaged;
				}
			};
		}
	}
}
