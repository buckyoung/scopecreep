using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

namespace ScopeCreep {

	[RequireComponent (typeof (IDamage))]

	public class Bullet : MonoBehaviour {
		private IDamage damager;

		void Start() {
			damager = GetComponent<IDamage>();
		}

		void OnTriggerEnter2D(Collider2D col) {
			IDamageable damageableObject = col.gameObject.GetComponent<IDamageable>();

			if (damageableObject != null) {
				damageableObject.damage(damager);
				Destroy(this.gameObject);
			}
		}
	}
}