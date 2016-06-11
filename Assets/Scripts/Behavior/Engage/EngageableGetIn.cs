using UnityEngine;
using System.Collections;
using ScopeCreep.Player;

namespace ScopeCreep.Module {
	public class EngageableGetIn : MonoBehaviour, IEngageable {
		private ShipModule[] modules;
		private SpriteRenderer[] moduleSprites;
		private SpriteRenderer[] playerSprites;
		private Vector4 originalColor;

		public void engage(ShipModule module, Player.Player player) {
			player.transform.position = new Vector3(
				transform.position.x, 
				transform.position.y, 
				player.transform.position.z
			); // Move player to center of module and ensure they keep their original z coordinate

			player.GetComponent<SpriteRenderer>().enabled = false; // Player "gets in"

			module.canActivePlayerDisengage = false; // activePlayer cannot disengage without help from other player
		}

		public void disengage(ShipModule module, Player.Player player) {
			player.GetComponent<SpriteRenderer>().enabled = true; // Player "gets out"
		}
	}
}
