using UnityEngine;
using System.Collections;

public class LilGuyModule : Module {
	private int previousActivePlayerId = 0; 
	private GameObject lilGuy;
	private BoxCollider2D lilGuyBoxCollider2D;
	private BoxCollider2D msBottomBoxCollider2D;
	private TractorBeamHandler tractorBeamHandler;

	void Start() {
		base.Start();

		lilGuy = GameObject.Find("LilGuy");
		lilGuyBoxCollider2D = lilGuy.GetComponent<BoxCollider2D>();
		msBottomBoxCollider2D = GameObject.Find("MSBottom").GetComponent<BoxCollider2D>();
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
		if (tractorBeamHandler.canInitiateTractorBeam) {
			checkTractorBeam();
		}
	}

	void engage() {
		int index = activePlayerId - 1;
		previousActivePlayerId = activePlayerId;

		players[index].GetComponent<SpriteRenderer>().enabled = false; // Player "enters" the childship
		canActivePlayerDisengage = false; // activePlayer cannot disengage without help from other player

		StartCoroutine( playAnimation_shipExit() );
	}

	void disengage() {
		int index = previousActivePlayerId - 1;
		previousActivePlayerId = 0;

		players[index].GetComponent<SpriteRenderer>().enabled = true; // Player "exits" the childship
	}

	void checkTractorBeam() {
		int inactivePlayerId = (activePlayerId % 2) + 1;

		if (Input.GetButtonDown(inactivePlayerId + "_BTN_X") && isPlayerTouching[inactivePlayerId-1]) {
			StartCoroutine( tractorBeamHandler.playAnimation_tractorBeam() );
		}
	}

	IEnumerator playAnimation_shipExit() {
		var shipAnimationTravelTime = .2f;
		var endPosition = lilGuy.transform.position - new Vector3(0f, 2f, 0f);

		canActivePlayerControlModule = false; // Player has no control of childship during animation
		Physics2D.IgnoreCollision(lilGuyBoxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership during animation

		yield return StartCoroutine( Utility.moveObjectInSeconds(lilGuy, endPosition, shipAnimationTravelTime) ); // Childship exits mothership over T seconds

		// After animation plays
		canActivePlayerControlModule = true; // Return childship control to player
		Physics2D.IgnoreCollision(lilGuyBoxCollider2D, msBottomBoxCollider2D, false); // Reenable collisions with mothership
		tractorBeamHandler.canInitiateTractorBeam = true; // Inactive player can now initiate the beam to bring player back
	}
}
