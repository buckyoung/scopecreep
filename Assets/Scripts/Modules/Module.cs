using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {
	public int activePlayerId = 0; // The player that is engaged with this module
	public bool canActivePlayerControlModule = true; // There may be times when the active player cannot move the module's tool (for example: if he is in the childship when it is entering/exiting the mothership)

	protected bool canActivePlayerDisengage = true; // There may be times when the active player cannot press X to disengage (for example: if he is on the childship)
	protected bool[] isPlayerTouching = new bool[2];
	protected GameObject[] players = new GameObject[2];

	protected void Start() {
		players[0] = GameObject.Find("Player1");
		players[1] = GameObject.Find("Player2");

		isPlayerTouching[0] = false;
		isPlayerTouching[1] = false;
	}

	protected void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") { 
			var index = col.gameObject.GetComponent<PlayerMovement>().playerId - 1;
			isPlayerTouching[index] = true;
		}
	}

	protected void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Player") { 
			var index = col.gameObject.GetComponent<PlayerMovement>().playerId - 1;
			isPlayerTouching[index] = false;
		}
	}

	protected void Update() {
		updateModuleInteractionForPlayer(1);
		updateModuleInteractionForPlayer(2);
	}

	private void updateModuleInteractionForPlayer(int playerId) {
		int index = playerId - 1;

		if (Input.GetButtonDown(playerId + "_BTN_X") && isPlayerTouching[index]) { 
			if (activePlayerId == 0) { // No active player
				// Engage with the module
				activePlayerId = playerId;
				players[index].GetComponent<PlayerMovement>().isAtModule = true;
			} else if (activePlayerId == playerId && canActivePlayerDisengage) { // You are the active player and you can disengage 
				// Disengage with the module
				activePlayerId = 0;
				players[index].GetComponent<PlayerMovement>().isAtModule = false;
			}
		}
	}
}
