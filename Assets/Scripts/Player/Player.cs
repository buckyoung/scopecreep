using UnityEngine;
using System.Collections;
using ScopeCreep.Module;
using ScopeCreep.Behavior;

namespace ScopeCreep.Player {
	
	[RequireComponent (typeof (IMoveable))]

	public class Player : MonoBehaviour {
		public IMoveable moveBehavior;
		public int id = 1;

		private bool isAtModule = false;
		
		void Start() {
			moveBehavior = GetComponent<IMoveable>();
			subscribe();
		}

		void FixedUpdate() {
			if (!isAtModule) {
				moveBehavior.move();
			}
		}

		/*
		 * User Functions
		 */
		void subscribe() {
			// The player interacted with a module
			ShipModule.onModuleInteraction += (eventObject, player, isEngaged) => {
				if (id == player.id) {
					isAtModule = isEngaged;
				}
			};
		}
	}
}