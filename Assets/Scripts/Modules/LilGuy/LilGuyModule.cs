using UnityEngine;
using System.Collections;

public class LilGuyModule : Module {
	private LilGuyMovement lilGuyMovement;
	private int previousActivePlayerId = 0; 
	private TractorBeam tractorBeam;

	delegate void UpdateDelegate();
	private UpdateDelegate updateDelegate;

	void Start() {
		base.Start();
		lilGuyMovement = GameObject.Find("LilGuy").GetComponent<LilGuyMovement>();
		tractorBeam = GameObject.Find("TractorBeam").GetComponent<TractorBeam>();
	}

	void Update() {
		base.Update();

		updateDelegate = null;

		// First frame after player has engaged with the module
		if (previousActivePlayerId == 0 && activePlayerId > 0) { 
			updateDelegate += engage;
		}

		// First frame after player has disengaged with the module
		if (activePlayerId == 0 && previousActivePlayerId > 0) { 
			updateDelegate += disengage;
		}

		// Check if inactive player has initiated the tractor beam
		if (tractorBeam.canInitiateTractorBeam()) {
			updateDelegate += checkTractorBeam;
		}

		if (updateDelegate != null) {
			updateDelegate();
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

		players[index].GetComponent<SpriteRenderer>().enabled = true; // Player "exits" the childship
	}

	private void engage() {
		int index = activePlayerId - 1;
		previousActivePlayerId = activePlayerId;

		players[index].GetComponent<SpriteRenderer>().enabled = false; // Player "enters" the childship
		canActivePlayerDisengage = false; // activePlayer cannot disengage without help from other player

		StartCoroutine( lilGuyMovement.playAnimation_shipExit() );
	}
}
