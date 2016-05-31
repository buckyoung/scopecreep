﻿using UnityEngine;
using System.Collections;
using ScopeCreep.System;
using ScopeCreep.CommonHandlers;

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

		private void OnDestroy() {
			HealthHandler.onDeath -= onDeathListener;
		}

		/*
		 * User Functions
		 */

		private void OnTriggerEnter2D(Collider2D col) {
			if ( col.gameObject.layer == LayerMask.NameToLayer("Childship") ) {
				target = col.gameObject;
				onEnemyFound(this, true);
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
				onEnemyFound(this, false);
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
				onEnemyFound(this, !isDead);
			}
		}
	}
}
