using UnityEngine;
using System.Collections;

public class LilGuyModule : Module {
	private bool canInitiateTractorBeam = false;
	private int previousActivePlayerId = 0; 
	private GameObject lilGuy;
	private BoxCollider2D lilGuyBoxCollider2D;
	private BoxCollider2D msBottomBoxCollider2D;

	void Start() {
		base.Start();

		lilGuy = GameObject.Find("LilGuy");
		lilGuyBoxCollider2D = lilGuy.GetComponent<BoxCollider2D>();
		msBottomBoxCollider2D = GameObject.Find("MSBottom").GetComponent<BoxCollider2D>();
	}

	void Update() {
		base.Update();

		// First frame after player has engaged with the module
		if (previousActivePlayerId == 0 && activePlayerId > 0) { 
			int index = activePlayerId - 1;
			previousActivePlayerId = activePlayerId;

			players[index].GetComponent<SpriteRenderer>().enabled = false; // Player "enters" the childship
			canActivePlayerDisengage = false; // activePlayer cannot disengage without help from other player

			StartCoroutine( playShipExitAnimation() );
		}

		// First frame after player has disengaged with the module
		if (activePlayerId == 0 && previousActivePlayerId > 0) { 
			int index = previousActivePlayerId - 1;
			previousActivePlayerId = 0;

			players[index].GetComponent<SpriteRenderer>().enabled = true; // Player "exits" the childship
		}
	}

	IEnumerator playShipExitAnimation() {
		var shipAnimationTravelTime = .2f;
		var endPosition = lilGuy.transform.position - new Vector3(0f, 2f, 0f);

		canActivePlayerControlModule = false; // Player has no control of childship during animation
		Physics2D.IgnoreCollision(lilGuyBoxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership during animation

		yield return StartCoroutine( moveInSeconds(lilGuy, endPosition, shipAnimationTravelTime) ); // Childship exits mothership over T seconds

		// After animation plays
		canActivePlayerControlModule = true; // Return childship control to player
		Physics2D.IgnoreCollision(lilGuyBoxCollider2D, msBottomBoxCollider2D, false); // Reenable collisions with mothership
		canInitiateTractorBeam = true; // Inactive player can now initiate the beam to bring player back
	}

	IEnumerator moveInSeconds(GameObject objectToMove, Vector3 end, float seconds) {
		float elapsedTime = 0;
		Vector3 start = objectToMove.transform.position;

		// TODO BUCK : Consider using the rb.AddRelativeForce here instead of transform position...

		while (elapsedTime < seconds) {
			objectToMove.transform.position = Vector3.Lerp(start, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		objectToMove.transform.position = end;
	}
}
