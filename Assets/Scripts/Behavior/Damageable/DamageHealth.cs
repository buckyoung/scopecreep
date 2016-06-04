﻿using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (BoxCollider2D))]

	public class DamageHealth : MonoBehaviour, IDamageable {
		public float health = 100.0f;
		public float maxHealth = 100.0f;

		public void damage(float amount) {
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

		public void heal(float amount) {
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