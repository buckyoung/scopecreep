using UnityEngine;
using System.Collections;
using ScopeCreep;
using ScopeCreep.Player;
using ScopeCreep.System;

namespace ScopeCreep.Module {

	[RequireComponent (typeof (IEngage))]
	[RequireComponent (typeof (SpriteRenderer))]

	public abstract class ShipModule : MonoBehaviour {
		public bool canActivePlayerControlModule = true; // There may be times when the active player cannot move the module's tool (for example: if he is in the childship when it is entering/exiting the mothership)
		public bool canActivePlayerDisengage = true; // There may be times when the active player cannot press X to disengage (for example: if he is on the childship)
		public int activePlayerId = 0; // The player that is engaged with this module
		public Player.Player[] players = new Player.Player[2];

		protected bool[] isPlayerTouching = new bool[2];
		protected IEngage engageBehavior;

		private SpriteRenderer spriteRenderer;
		private Vector4 originalColor;

		// Events
		public delegate void ModuleInteractionEvent(ShipModule eventObject, Player.Player player, bool isEngaged);
		public static event ModuleInteractionEvent onModuleInteraction;

		protected void Start() {
			players[0] = GameObject.Find("Player1").GetComponent<Player.Player>();
			players[1] = GameObject.Find("Player2").GetComponent<Player.Player>();

			isPlayerTouching[0] = false;
			isPlayerTouching[1] = false;

			engageBehavior = GetComponent<IEngage>();

			spriteRenderer = GetComponent<SpriteRenderer>();
			originalColor = spriteRenderer.color;

			subscribe();
		}

		protected void OnTriggerEnter2D(Collider2D col) {
			if (col.gameObject.tag == "Player") { 
				var index = col.gameObject.GetComponent<Player.Player>().id - 1;
				isPlayerTouching[index] = true;
			}
		}

		protected void OnTriggerExit2D(Collider2D col) {
			if (col.gameObject.tag == "Player") { 
				var index = col.gameObject.GetComponent<Player.Player>().id - 1;
				isPlayerTouching[index] = false;
			}
		}

		/*
		 * User Functions
		 */

		private void subscribe() {
			// Check if module interaction
			ButtonEventManager.onXButtonDown += (eventObject, playerId) => {
				if (isPlayerTouching[ playerId - 1 ]) { // Is the player touching this module when they hit X?
					if (activePlayerId == 0) { // No active player
						performEngage(playerId);
					} else if (activePlayerId == playerId && canActivePlayerDisengage) { // You are the active player and you can disengage 
						performDisengage(playerId);
					}
				}
			};
		}

		public void performDisengage(int playerId) {
			int index = playerId -1;

			activePlayerId = 0;
			engageBehavior.disengage(this, players[index]);
			toggleModuleGlow(false);

			if (onModuleInteraction != null) onModuleInteraction(this, players[index], false);
		}

		private void performEngage(int playerId) {
			int index = playerId -1;

			activePlayerId = playerId;
			engageBehavior.engage(this, players[playerId-1]);
			toggleModuleGlow(true);

			if (onModuleInteraction != null) onModuleInteraction(this, players[index], true);
		}

		private void toggleModuleGlow(bool isEngage) {
			if (isEngage) {
				spriteRenderer.color = originalColor * 1.8f;
			} else {
				spriteRenderer.color = originalColor;
			}
		}
	}
}