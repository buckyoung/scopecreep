using UnityEngine;
using System.Collections;

public class LilGuyModule : Module {
	private LilGuyMovement lilGuyMovement;
	private int previousActivePlayerId = 0; 
	private TractorBeamHandler tractorBeamHandler;

	void Start() {
		base.Start();
		lilGuyMovement = GameObject.Find("LilGuy").GetComponent<LilGuyMovement>();
		tractorBeamHandler = GameObject.Find("TractorBeam").GetComponent<TractorBeamHandler>();
	}

	void Update() {
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
		if (tractorBeamHandler.canInitiateTractorBeam()) {
			checkTractorBeam();
		}
	}

	private void engage() {
		int index = activePlayerId - 1;
		previousActivePlayerId = activePlayerId;

		players[index].GetComponent<SpriteRenderer>().enabled = false; // Player "enters" the childship
		canActivePlayerDisengage = false; // activePlayer cannot disengage without help from other player

		StartCoroutine( lilGuyMovement.playAnimation_shipExit() );
	}

	private void disengage() {
		int index = previousActivePlayerId - 1;
		previousActivePlayerId = 0;

		players[index].GetComponent<SpriteRenderer>().enabled = true; // Player "exits" the childship
	}

	private void checkTractorBeam() {
		int inactivePlayerId = (activePlayerId % 2) + 1;

		if (Input.GetButtonDown(inactivePlayerId + "_BTN_X") && isPlayerTouching[inactivePlayerId-1]) {
			StartCoroutine( tractorBeamHandler.playAnimation_tractorBeam() );
		}
	}
}
