using UnityEngine;
using System.Collections;
using ScopeCreep.Player;

namespace ScopeCreep.Module {
	public class EngageableSitDown : MonoBehaviour, IEngageable {
		private ShipModule[] modules;
		private SpriteRenderer[] moduleSprites;
		private SpriteRenderer[] playerSprites;
		private Vector4 originalColor;

		public void engage(ShipModule module, Player.Player player) {
			moveHalfwayTowardCenter(player, module);
		}

		public void disengage(ShipModule module, Player.Player player) {
			// Do nothing
		}

		private void moveHalfwayTowardCenter(Player.Player player, ShipModule module) {
			float halfwayX = (module.transform.position.x - player.transform.position.x) / 2;
			float newX = player.transform.position.x + halfwayX;

			// Teleport player toward center of module and ensure they keep their original y & z coordinate
			// This HACK ensures the player is touching the module and hasnt slid past when engaging
			// and should be removed at some point TODO BUCK
			player.transform.position = new Vector3(
				newX,
				player.transform.position.y,
				player.transform.position.z
			); 
		}
	}
}