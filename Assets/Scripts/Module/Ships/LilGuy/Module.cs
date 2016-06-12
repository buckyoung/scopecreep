using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.System;

namespace ScopeCreep.Module.LilGuy { 
	public class Module : ShipModule {
		private Animations lilGuyAnimation;
		private TractorBeam tractorBeam;

		new void Start() {
			base.Start();

			lilGuyAnimation = GameObject.Find("LilGuy").GetComponent<Animations>();
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
					StartCoroutine( lilGuyAnimation.shipExit() );
				}
			};
		}
	}
}