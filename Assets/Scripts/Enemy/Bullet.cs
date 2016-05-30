using UnityEngine;
using System.Collections;

namespace ScopeCreep.Enemy.Bullet {
	public class Bullet : MonoBehaviour {
		public int damageToDeal = 2;

		void OnCollisionEnter2D(Collision2D col) {
			if ( col.gameObject.layer != LayerMask.NameToLayer("Enemy") ) {
				Destroy(this.gameObject);
			}
		}
	}
}