using UnityEngine;
using System.Collections;
using ScopeCreep.Player;

namespace ScopeCreep.Module {
	public class EngageSitDown : MonoBehaviour, IEngage {
		private SpriteRenderer[] playerSprites;
		private SpriteRenderer[] moduleSprites;
		private ShipModule[] modules;
		private Vector4 originalColor;

		public void engage(ShipModule module, PlayerInfo player) {
			
		}

		public void disengage(ShipModule module, PlayerInfo player) {
			
		}
	}
}