using UnityEngine;
using System.Collections;
using ScopeCreep.System;

namespace ScopeCreep.Enemy.TurretBase {
	public class TurretBase : MonoBehaviour {
		public GameObject target = null;
		public float speed = 5;

		//Events
		public delegate void EnemyFoundEvent(TurretBase eventObject, bool isFound);
		public static event EnemyFoundEvent onEnemyFound;

		void Start() {
			subscribe();
		}

		void Update() {
			if (target != null) {
				transform.rotation = Quaternion.SlerpUnclamped(
					transform.rotation,
					transform.position.getRotationTo(target.transform.position), 
					Time.deltaTime * speed
				);
			}
		}

		private void OnTriggerEnter2D(Collider2D col) {
			if ( col.gameObject.layer == LayerMask.NameToLayer("Childship") ) {
				target = col.gameObject;
				onEnemyFound(this, true);
			}
		}

		private void OnTriggerExit2D(Collider2D col) {
			if ( col.gameObject.layer == LayerMask.NameToLayer("Childship") ) {
				target = null;
				onEnemyFound(this, false);
			}
		}

		/*
		 * User Functions
		 */
		void subscribe() {
			ScopeCreep.CommonHandlers.HealthHandler.onDeath += (eventObject, isDead) => {
				if (eventObject.gameObject == target) {
					onEnemyFound(this, !isDead);
				}
			};
		}
	}
}
