using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

namespace ScopeCreep.Module.LilGuy { 

	[RequireComponent (typeof (IMoveable))]

	public class Movement : MonoBehaviour {
		private bool hasFuel = true;
		private IMoveable moveBehavior;
		private Module lilGuyModule;

		void Start() {
			lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<Module>();
			moveBehavior = GetComponent<IMoveable>();

			subscribe();
		}

		void FixedUpdate() {
			if (lilGuyModule.activePlayerId > 0 && lilGuyModule.canActivePlayerControlModule && hasFuel) {
				moveBehavior.move();
			}
		}

		/*
		 * User Functions
		 */
		private void subscribe() {
			ResourceHandler.onFuelEvent += (eventObject, hasFuel) => {
				if (eventObject.gameObject.name == "LilGuy") {
					this.hasFuel = hasFuel;
				}
			};
		}
	}
}