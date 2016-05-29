using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module {
	public abstract class ShipModule : MonoBehaviour {
		public int activePlayerId = 0; // The player that is engaged with this module
		public bool canActivePlayerControlModule = true; // There may be times when the active player cannot move the module's tool (for example: if he is in the childship when it is entering/exiting the mothership)
		public bool canActivePlayerDisengage = true; // There may be times when the active player cannot press X to disengage (for example: if he is on the childship)

		protected bool[] isPlayerTouching = new bool[2];
		protected Vector4 originalColor;
		protected GameObject[] players = new GameObject[2];
		protected SpriteRenderer spriteRenderer;

		// Events
		public delegate void ModuleInteractionEvent(ShipModule eventObject, int playerId, bool isEngaged);
		public static event ModuleInteractionEvent onModuleInteraction;

		protected void Start() {
			players[0] = GameObject.Find("Player1");
			players[1] = GameObject.Find("Player2");

			isPlayerTouching[0] = false;
			isPlayerTouching[1] = false;

			spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			originalColor = spriteRenderer.color;
		}

		protected void OnTriggerEnter2D(Collider2D col) {
			if (col.gameObject.tag == "Player") { 
				var index = col.gameObject.GetComponent<Player.Movement>().playerId - 1;
				isPlayerTouching[index] = true;
			}
		}

		protected void OnTriggerExit2D(Collider2D col) {
			if (col.gameObject.tag == "Player") { 
				var index = col.gameObject.GetComponent<Player.Movement>().playerId - 1;
				isPlayerTouching[index] = false;
			}
		}

		protected void Update() {
			updateModuleInteractionForPlayer(1);
			updateModuleInteractionForPlayer(2);
		}

		/*
		 * User Functions
		 */

		public void disengage(int playerId) {
			activePlayerId = 0;
			spriteRenderer.color = originalColor;

			if (onModuleInteraction != null) onModuleInteraction(this, playerId, false);
		}

		private void engage(int playerId, int index) {
			activePlayerId = playerId;
			spriteRenderer.color = originalColor * 1.8f;

			players[index].transform.position = new Vector3(
				transform.position.x, 
				transform.position.y, 
				players[index].transform.position.z
			); // Move player to center of module and ensure they keep their original z coordinate

			if (onModuleInteraction != null) onModuleInteraction(this, playerId, true);
		}

		private void updateModuleInteractionForPlayer(int playerId) {
			int index = playerId - 1;

			if (Input.GetButtonDown(playerId + "_BTN_X") && isPlayerTouching[index]) { 
				if (activePlayerId == 0) { // No active player
					engage(playerId, index);
				} else if (activePlayerId == playerId && canActivePlayerDisengage) { // You are the active player and you can disengage 
					disengage(playerId);
				}
			}
		}
	}
}