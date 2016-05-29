using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.System;

namespace ScopeCreep.Module.LilGuy { 
	public class Module : ShipModule {
		private Movement movement;
		private TractorBeam tractorBeam;

		new void Start() {
			base.Start();

			movement = GameObject.Find("LilGuy").GetComponent<Movement>();
			tractorBeam = GameObject.Find("TractorBeam").GetComponent<TractorBeam>();

			subscribe();
		}

		/*
		 * User Functions
		 */

		private void subscribe() {
			// Check if inactive player has initiated the tractor beam
			ButtonEventManager.onXButtonDown += (eventObject, playerId) => {
				if (tractorBeam.canInitiateTractorBeam()) {
					int inactivePlayerId = (activePlayerId % 2) + 1;

					if (inactivePlayerId == playerId && isPlayerTouching[inactivePlayerId-1]) {
						StartCoroutine( tractorBeam.playAnimation_tractorBeam() );
					}
				}
			};

			// Run ship exit animation
			ShipModule.onModuleInteraction += (eventObject, playerId, isEngaged) => {
				if (eventObject is LilGuy.Module && isEngaged) {
					StartCoroutine( movement.playAnimation_shipExit() );
				}
			};
		}
	}
}