using UnityEngine;
using System.Collections;

namespace ScopeCreep.CommonHandlers {
	public class HealthHandler : MonoBehaviour {
		public int hitPoints = 100;

		// Events
		public delegate void DeathEvent(HealthHandler eventObject, bool isDead);
		public static event DeathEvent onDeath;

		void Update() {
			if (hitPoints <= 0) {
				if (onDeath != null) onDeath(this, true);

				Destroy(this.gameObject);
			}
		}

		void OnCollisionEnter2D(Collision2D col) {
			GameObject colObj = col.gameObject;

			if ( colObj.CompareTag("EnemyBullet")) {
				hitPoints = hitPoints - colObj.GetComponent<ScopeCreep.Enemy.Bullet.Bullet>().damageToDeal;
			}
		}

		/*
		 * User Functions
		 */
		public int gethitPoints() {
			return hitPoints; 
		}
	}
}
