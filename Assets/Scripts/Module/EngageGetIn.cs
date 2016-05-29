using UnityEngine;
using System.Collections;
using ScopeCreep.Player;

namespace ScopeCreep.Module {
	public class EngageGetIn : MonoBehaviour, IEngage {
		private SpriteRenderer[] playerSprites;
		private SpriteRenderer[] moduleSprites;
		private ShipModule[] modules;
		private Vector4 originalColor;

		public void engage(ShipModule module, PlayerInfo player) {
			player.transform.position = new Vector3(
				transform.position.x, 
				transform.position.y, 
				player.transform.position.z
			); // Move player to center of module and ensure they keep their original z coordinate

			player.GetComponent<SpriteRenderer>().enabled = false; // Player "gets in"

			module.canActivePlayerDisengage = false; // activePlayer cannot disengage without help from other player
		}

		public void disengage(ShipModule module, PlayerInfo player) {
			player.GetComponent<SpriteRenderer>().enabled = true; // Player "gets out"
		}
	}
}
