using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	
	[RequireComponent (typeof (Collider2D))] // Required for collision with IDamageable

	public class DamageBullet : MonoBehaviour, IDamage {
		[Range (0.0f, 1000.0f)]
		public float amount = 1.0f;

		public float getAmount() {
			return amount;
		}
	}
}