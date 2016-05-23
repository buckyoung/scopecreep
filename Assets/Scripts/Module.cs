using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {
	public int activePlayerId = 0;

	private bool isPlayer1Touching = false;
	private bool isPlayer2Touching = false;
	private GameObject player1;
	private GameObject player2;

	void Start() {
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag != "Player") { return; }

		PlayerMovement playerMovement = col.gameObject.GetComponent<PlayerMovement>();

		if (playerMovement.playerId == 1 ) {
			isPlayer1Touching = true;
		}

		if (playerMovement.playerId == 2 ) {
			isPlayer2Touching = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag != "Player") { return; }

		PlayerMovement playerMovement = col.gameObject.GetComponent<PlayerMovement>();

		if (playerMovement.playerId == 1 ) {
			isPlayer1Touching = false;
		}

		if (playerMovement.playerId == 2 ) {
			isPlayer2Touching = false;
		}
	}

	void Update() {

		// If you press the button And are touching the module
				// And the module has no active player
					// Become active player
				// Else if you are the active player
					// UNbecome the active player

		if (Input.GetButtonDown("1_BTN_X") && isPlayer1Touching) { 
			if (activePlayerId == 0) { // No active player
				// Engage with the module
				activePlayerId = 1;
				player1.GetComponent<PlayerMovement>().isAtModule = true;
			} else if (activePlayerId == 1) { // You are the active player
				// Disengage with the module
				activePlayerId = 0;
				player1.GetComponent<PlayerMovement>().isAtModule = false;
			}
		}

		if (Input.GetButtonDown("2_BTN_X") && isPlayer2Touching) { 
			if (activePlayerId == 0) { // No active player
				// Engage with the module
				activePlayerId = 2;
				player2.GetComponent<PlayerMovement>().isAtModule = true;
			} else if (activePlayerId == 2) { // You are the active player
				// Disengage with the module
				activePlayerId = 0;
				player2.GetComponent<PlayerMovement>().isAtModule = false;
			}
		}

		// TODO buck For player 2
	}
}
