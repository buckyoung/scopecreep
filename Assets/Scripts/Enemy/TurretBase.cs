using UnityEngine;
using System.Collections;
using ScopeCreep.System;
using ScopeCreep.CommonHandlers;
using ScopeCreep.Behavior;

namespace ScopeCreep.Enemy.TurretBase {

	[RequireComponent (typeof (IAimable))]

	public class TurretBase : MonoBehaviour {
		public GameObject target = null;

		public IAimable aimBehavior;

		//Events
		public delegate void EnemyFoundEvent(TurretBase eventObject, bool isFound);
		public static event EnemyFoundEvent onEnemyFound;

		void Start() {
			aimBehavior = GetComponent<IAimable>();

			subscribe();
		}

		void Update() {
			aimBehavior.aimAt(target);
		}

		private void OnDestroy() {
			HealthHandler.onDeath -= onDeathListener;
		}

		/*
		 * User Functions
		 */

		private void OnTriggerEnter2D(Collider2D col) {
			if ( col.gameObject.layer == LayerMask.NameToLayer("Childship") ) {
				target = col.gameObject;
				if (onEnemyFound != null) onEnemyFound(this, true);
			}

			// TODO BUCK Generalize this rule -- this is used during the planet gen process
			if (col.gameObject.transform.parent != null 
				&& col.gameObject.transform.parent.name == "TowerGun(Clone)" 
				&& !col.gameObject.transform.parent.gameObject.Equals(this.gameObject.transform.parent.gameObject)) {
				Destroy(col.gameObject.transform.parent.gameObject);
			}
		}

		private void OnTriggerExit2D(Collider2D col) {
			if ( col.gameObject.layer == LayerMask.NameToLayer("Childship") ) {
				target = null;
				if (onEnemyFound != null) onEnemyFound(this, false);
			}
		}

		/*
		 * User Functions
		 */
		private void subscribe() {
			HealthHandler.onDeath += onDeathListener;
		}


		private void onDeathListener(HealthHandler eventObject, bool isDead) {
			if (eventObject.gameObject == target) {
				if (onEnemyFound != null) onEnemyFound(this, !isDead);
			}
		}
	}
}
