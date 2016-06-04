using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (BoxCollider2D))] // Required so IDamage can collide

	public class DamageableHealth : MonoBehaviour, IDamageable {
		public float health = 100.0f;
		public float maxHealth = 100.0f;

		public void damage(IDamage damager) {
			float amount = damager.getAmount();

			if (amount < 0) {
				Debug.LogWarning("Warning: damage amount cannot be less than 0", this);
				return;
			}

			health -= amount;

			if (health < 0) {
				die();
			}
		}

		public void die() {
			Destroy(this.gameObject); // Must be on top level game object!
		}

		public float getHealth() {
			return health;
		}

		public void heal(IHeal healer) {
			float amount = healer.getAmount();

			if (amount < 0) {
				Debug.LogWarning("Warning: heal amount cannot be less than 0", this);
				return;
			}

			health += amount;

			if (health > maxHealth) {
				health = maxHealth;
			}
		}
	}
}