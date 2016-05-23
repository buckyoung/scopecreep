using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {
	public int activePlayerId = 0;

	protected bool[] isTouching;
	protected GameObject[] players;

	void Start() {
		players[0] = GameObject.Find("Player1");
		players[1] = GameObject.Find("Player2");

		isTouching[0] = false;
		isTouching[1] = false;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag != "Player") { return; }

		setIsTouching(col.gameObject.GetComponent<PlayerMovement>(), true);
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag != "Player") { return; }

		setIsTouching(col.gameObject.GetComponent<PlayerMovement>(), false);
	}

	void Update() {
		checkButtonEventForPlayer(1);
		checkButtonEventForPlayer(2);
	}

	private void checkButtonEventForPlayer(int playerId) {
		int index = playerId - 1;

		if (Input.GetButtonDown(playerId + "_BTN_X") && isTouching[index]) { 
			if (activePlayerId == 0) { // No active player
				// Engage with the module
				activePlayerId = playerId;
				players[index].GetComponent<PlayerMovement>().isAtModule = true;
			} else if (activePlayerId == playerId) { // You are the active player
				// Disengage with the module
				activePlayerId = 0;
				players[index].GetComponent<PlayerMovement>().isAtModule = false;
			}
		}
	}

	private void setIsTouching(PlayerMovement playerMovement, bool value) {
		if (playerMovement.playerId == 1) {
			isTouching[0] = value;
		}

		if (playerMovement.playerId == 2) {
			isTouching[1] = value;
		}
	} 
}
