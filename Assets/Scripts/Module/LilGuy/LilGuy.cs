using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module.LilGuy { 
	public class LilGuy : Module {
		private Movement movement;
		private int previousActivePlayerId = 0; 
		private TractorBeam tractorBeam;

		// Events
		public delegate void LilGuyInteractionEvent(LilGuy eventObject, bool isEngaged);
		public static event LilGuyInteractionEvent onLilGuyInteraction;

		new void Start() {
			base.Start();
			movement = GameObject.Find("LilGuy").GetComponent<Movement>();
			tractorBeam = GameObject.Find("TractorBeam").GetComponent<TractorBeam>();
		}

		new void Update() {
			base.Update();

			// First frame after player has engaged with the module
			if (previousActivePlayerId == 0 && activePlayerId > 0) { 
				engage();
			}

			// First frame after player has disengaged with the module
			if (activePlayerId == 0 && previousActivePlayerId > 0) { 
				disengage();
			}

			// Check if inactive player has initiated the tractor beam
			if (tractorBeam.canInitiateTractorBeam()) {
				checkTractorBeam();
			}
		}

		/*
		 * User Functions
		 */
		
		private void checkTractorBeam() {
			int inactivePlayerId = (activePlayerId % 2) + 1;

			if (Input.GetButtonDown(inactivePlayerId + "_BTN_X") && isPlayerTouching[inactivePlayerId-1]) {
				StartCoroutine( tractorBeam.playAnimation_tractorBeam() );
			}
		}

		private void disengage() {
			int index = previousActivePlayerId - 1;
			previousActivePlayerId = 0;

			if (onLilGuyInteraction != null) onLilGuyInteraction(this, false);

			players[index].GetComponent<SpriteRenderer>().enabled = true; // Player "exits" the childship
		}

		private void engage() {
			int index = activePlayerId - 1;
			previousActivePlayerId = activePlayerId;

			if (onLilGuyInteraction != null) onLilGuyInteraction(this, true);

			players[index].GetComponent<SpriteRenderer>().enabled = false; // Player "enters" the childship
			canActivePlayerDisengage = false; // activePlayer cannot disengage without help from other player

			StartCoroutine( movement.playAnimation_shipExit() );
		}
	}
}