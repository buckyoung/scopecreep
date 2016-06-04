using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public class DamageBullet : MonoBehaviour, IDamage {
		public float amount = 1.0f;

		public float getAmount() {
			return amount;
		}
	}
}