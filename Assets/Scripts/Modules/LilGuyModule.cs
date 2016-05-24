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
			players[index].GetComponent<SpriteRenderer>().enabled = false; // Player "enters" the childship
			previousActivePlayerId = activePlayerId;

			canActivePlayerDisengage = false; // activePlayer cannot disengage without help from other player

			playShipExitAnimation();
		}

		// First frame after player has disengaged with the module
		if (activePlayerId == 0 && previousActivePlayerId > 0) { 
			int index = previousActivePlayerId - 1;
			players[index].GetComponent<SpriteRenderer>().enabled = true; // Player "exits" the childship
			previousActivePlayerId = 0;
		}
	}

	void playShipExitAnimation() {
		var shipAnimationTravelTime = .2f;
		var endPosition = lilGuy.transform.position - new Vector3(0f, 2f, 0f);

		canActivePlayerControlModule = false; // Player has no control of childship during animation
		Physics2D.IgnoreCollision(lilGuyBoxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership
		StartCoroutine( moveInSeconds(lilGuy, endPosition, shipAnimationTravelTime) ); // Animation: childship exits mothership
		StartCoroutine( callbackShipExitAnimationComplete(shipAnimationTravelTime + 0.001f) ); // Things to do after animation ends
	}

	IEnumerator moveInSeconds(GameObject objectToMove, Vector3 end, float seconds) {
		float elapsedTime = 0;
		Vector3 start = objectToMove.transform.position;

		// TODO BUCK : Consider using the rb.AddRelativeForce here...

		while (elapsedTime < seconds) {
			objectToMove.transform.position = Vector3.Lerp(start, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		objectToMove.transform.position = end;
	}

	IEnumerator callbackShipExitAnimationComplete(float seconds) {
		yield return new WaitForSeconds(seconds);

		canActivePlayerControlModule = true; // Player has control of childship now
		Physics2D.IgnoreCollision(lilGuyBoxCollider2D, msBottomBoxCollider2D, false); // Ship will not collide with bottom of mothership
		canInitiateTractorBeam = true; // Inactive player can now initiate the beam  
	}
}
