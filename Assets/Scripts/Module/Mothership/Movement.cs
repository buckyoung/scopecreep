using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.Mothership { 

	[RequireComponent (typeof (IMoveable))]

	public class Movement : MonoBehaviour {
		private bool hasFuel = true;
		private IMoveable moveBehavior;
		private Module mothershipModule;

		void Start() {
			mothershipModule = GameObject.Find("MothershipModule").GetComponent<Module>();

			moveBehavior = GetComponent<IMoveable>();

			subscribe();
		}

		void Update() {
			if (mothershipModule.activePlayerId > 0 && mothershipModule.canActivePlayerControlModule && hasFuel) {
				moveBehavior.move();
			}
		}

		/*
		 * User Functions
		 */

		private void subscribe() {
			ResourceHandler.onFuelEvent += (eventObject, hasFuel) => {
				if (eventObject.gameObject.name == "MothershipModule") {
					this.hasFuel = hasFuel;
				}
			};
		}
	}
}