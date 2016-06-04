using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

namespace ScopeCreep.Enemy.Bullet {

	[RequireComponent (typeof (IDamage))]

	public class Bullet : MonoBehaviour {
		private IDamage damager;

		void Start() {
			damager = GetComponent<IDamage>();
		}

		void OnCollisionEnter2D(Collision2D col) {
			IDamageable damageableObject = col.gameObject.GetComponent<IDamageable>();

			if (damageableObject != null) {
				damageableObject.damage(damager);
			}

			if ( col.gameObject.layer != LayerMask.NameToLayer("Enemy") ) {
				Destroy(this.gameObject);
			}
		}
	}
}