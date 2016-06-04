using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	
	[RequireComponent (typeof (Collider2D))] // Required for collision with IDamageable

	public class DamageBullet : MonoBehaviour, IDamage {
		private float amount = 1.0f;

		public float getAmount() {
			return amount;
		}

		public void setAmount(float amount) {
			this.amount = amount;
		}
	}
}